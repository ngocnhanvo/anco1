#!/usr/bin/env python3
"""Guarded one-time integration of the post-baseline Excel feature into Azure.

Use ONLY when the historical baseline excludes DHD features still present in
GitHub but absent in Azure. This copies an independently implemented Excel
feature, not the entire GitHub handler/JS files or excluded legacy changes.
Every source and insertion anchor is verified before staging.
"""
from pathlib import Path
import subprocess

HANDLER = "eman_ver3/Controller/JQGridModify/JQGridMD_00_DSHangHoa_SOANTHAOModify.ashx"
JAVASCRIPT = "eman_ver3/js/Module_script/MD_00_DSHangHoa_SOANTHAO.js"
EXCEL_START = "    // BEGIN ANCO1_EXCEL_SOANTHAO_EXPORT (post-baseline feature only)"
EXCEL_END = "    // END ANCO1_EXCEL_SOANTHAO_EXPORT"
JS_START = "//start CA01ExportHHVG_MD00DSHangHoaSOANTHAO"
JS_END = "//end CA01ExportHHVG_MD00DSHangHoaSOANTHAO"
CASE_BASE = (
    '            case "CA01ImportHHVG_MD00DSHangHoaSOANTHAO":\n'
    '                this.CA01ImportHHVG_MD00DSHangHoaSOANTHAO(context);\n'
    '                break;\n'
)
CASE_ADDITION = (
    '            case "CA01ExportHHVG_MD00DSHangHoaSOANTHAO":\n'
    '                this.ExportExcelHHVGSOANTHAO(context);\n'
    '                break;\n'
)


def decoded(data):
    """Return normalized text while tracking Azure BOM/newline style."""
    bom = data.startswith(b"\xef\xbb\xbf")
    crlf = b"\r\n" in data
    return data.decode("utf-8-sig").replace("\r\n", "\n"), bom, crlf


def encoded(text, bom, crlf):
    return (b"\xef\xbb\xbf" if bom else b"") + text.replace(
        "\n", "\r\n" if crlf else "\n"
    ).encode("utf-8")


def one_region(text, start, end):
    if text.count(start) != 1 or text.count(end) != 1:
        raise RuntimeError("Excel feature region markers not unique.")
    a = text.index(start)
    b = text.index(end, a) + len(end)
    return text[a:b]


def baseline_text(source_repo, baseline, path):
    data = subprocess.check_output(
        ["git", "show", "{}:{}".format(baseline, path)], cwd=str(source_repo)
    )
    return decoded(data)[0]


def apply_guarded_excel_only(azure_repo, source_repo, baseline, changed):
    """Perform exact two-file feature integration with explicit safety guards."""
    expected = {HANDLER, JAVASCRIPT}
    if set(changed) != expected or len(changed) != 2:
        raise RuntimeError(
            "Excel bootstrap is only valid for the two known export source files."
        )
    azure_repo = Path(azure_repo)
    source_repo = Path(source_repo)

    current_js, js_bom, js_crlf = decoded((azure_repo / JAVASCRIPT).read_bytes())
    github_js = decoded((source_repo / JAVASCRIPT).read_bytes())[0]
    original_js = baseline_text(source_repo, baseline, JAVASCRIPT)
    old_region = one_region(current_js, JS_START, JS_END)
    original_region = one_region(original_js, JS_START, JS_END)
    if old_region != original_region:
        raise RuntimeError(
            "Azure Excel JS function diverged from the documented baseline: refusing overwrite."
        )
    new_region = one_region(github_js, JS_START, JS_END)
    if old_region == new_region:
        raise RuntimeError("Unexpected Excel JS source: already identical.")
    new_js = current_js.replace(old_region, new_region)
    if new_js.count(JS_START) != 1:
        raise RuntimeError("Excel JS transformation was not unique.")

    current_handler, cs_bom, cs_crlf = decoded((azure_repo / HANDLER).read_bytes())
    github_handler = decoded((source_repo / HANDLER).read_bytes())[0]
    feature = one_region(github_handler, EXCEL_START, EXCEL_END)
    if not all(token in feature for token in [
        "GetExportProductIds(", "GetExportDraftIds(", "GetExportSnapshot(",
        "public void ExportExcelHHVGSOANTHAO(", "DraftExportHeaders",
        "Security.PhanQuyen_ChucNang(", "sp.md_sanpham_id IN (/*EXPORT_FILTER_IDS*/)"
    ]):
        raise RuntimeError("GitHub export code is not standalone/validated.")
    if current_handler.count(CASE_BASE) != 1 or current_handler.count(
        "    public bool IsReusable\n"
    ) != 1:
        raise RuntimeError("Azure handler entry points differ; refusing injection.")
    if "CA01ExportHHVG_MD00DSHangHoaSOANTHAO" in current_handler:
        raise RuntimeError("Azure export case exists already; refusing duplicate.")
    new_handler = current_handler.replace(CASE_BASE, CASE_BASE + CASE_ADDITION)
    new_handler = new_handler.replace(
        "    public bool IsReusable\n",
        feature + "\n\n    public bool IsReusable\n"
    )
    if new_handler.count(EXCEL_START) != 1 or new_handler.count(
        "public void ExportExcelHHVGSOANTHAO("
    ) != 1:
        raise RuntimeError("Excel handler injection failed integrity checks.")

    (azure_repo / JAVASCRIPT).write_bytes(encoded(new_js, js_bom, js_crlf))
    (azure_repo / HANDLER).write_bytes(encoded(new_handler, cs_bom, cs_crlf))
    subprocess.run(
        ["git", "-C", str(azure_repo), "add", "--", HANDLER, JAVASCRIPT],
        check=True,
    )
    subprocess.run(["git", "-C", str(azure_repo), "diff", "--cached", "--check"],
                   check=True)
    print("Guarded Excel bootstrap: added export case, standalone 37-column "
          "NPOI methods and updated export JS only; DHD/history left untouched.")


def remove_exact_popup_line(azure_repo, source_repo, start, head):
    """Apply only the user's single-line SOANTHAO popup cleanup in Azure.

    The GitHub delta must be *exactly* this one deletion; preserve any unrelated
    Azure-side JavaScript changes. Called only after the VG JS patch applies
    cleanly and after the Azure clone's working tree was reset.
    """
    obsolete = (
        "                $('<p>').text("
        "'Tệp Excel 97-2003 (.xls), 37 cột đúng mẫu, không có 4 cột ẩn.'"
        ").appendTo($content);"
    )
    from_github = baseline_text(source_repo, start, JAVASCRIPT)
    to_github = baseline_text(source_repo, head, JAVASCRIPT)
    if (from_github.count(obsolete + "\n") != 1
            or from_github.replace(obsolete + "\n", "", 1) != to_github):
        raise RuntimeError(
            "SOANTHAO GitHub diff contains changes besides the requested popup line."
        )

    target_path = Path(azure_repo) / JAVASCRIPT
    azure_text, bom, crlf = decoded(target_path.read_bytes())
    fragment = one_region(azure_text, JS_START, JS_END)
    if fragment.count(obsolete + "\n") != 1:
        raise RuntimeError(
            "The expected SOANTHAO popup line is not unique in Azure; "
            "manual conflict resolution required."
        )
    corrected = azure_text.replace(obsolete + "\n", "", 1)
    target_path.write_bytes(encoded(corrected, bom, crlf))
    subprocess.run(
        ["git", "-C", str(azure_repo), "add", "--", JAVASCRIPT],
        check=True,
    )
    # Anco1 JavaScript uses Windows CRLF. Git must not treat CR at EOL
    # as trailing whitespace; real spaces before CR are still checked.
    subprocess.run(
        ["git", "-C", str(azure_repo), "-c", "core.whitespace=cr-at-eol",
         "diff", "--cached", "--check"],
        check=True,
    )
    print("Removed exactly the requested SOANTHAO popup line on Azure "
          "without touching any other JavaScript.")
