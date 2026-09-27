<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BaoCaoBOMHHVT2.aspx.cs" Inherits="PrintControllers_MD_00_Baocaoketoan_BaoCaoBOMHHVT2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>BOM HHVT mới nhất</title>
    <style type="text/css">
        body { margin: 0; padding: 16px; font-family: Arial, sans-serif; background: #f5f5f5; color: #222; }
        .toolbar { position: sticky; top: 0; z-index: 10; padding: 10px; margin-bottom: 12px; background: #fff; border: 1px solid #ddd; }
        .btn { padding: 8px 16px; font-weight: bold; cursor: pointer; }
        .summary { margin-left: 14px; color: #666; }
        .table-wrap { overflow: auto; max-height: calc(100vh - 90px); background: #fff; border: 1px solid #ccc; }
        table { border-collapse: collapse; font-size: 12px; white-space: nowrap; }
        th, td { border: 1px solid #bbb; padding: 5px 7px; }
        th { position: sticky; top: 0; z-index: 2; background: #eee; text-align: center; }
        th:first-child, td:first-child { position: sticky; left: 0; z-index: 1; background: #fff; }
        th:first-child { z-index: 3; background: #eee; }
        td.num { text-align: right; }
        td.code { font-weight: 600; }
        .empty { padding: 24px; text-align: center; color: #777; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="toolbar">
            <asp:Button ID="btnExportExcel" runat="server" Text="Xuất Excel dữ liệu (.xls)" CssClass="btn" OnClick="btnExportExcel_Click" />
            <asp:Literal ID="litSummary" runat="server" />
        </div>
        <div class="table-wrap">
            <asp:Literal ID="litMatrix" runat="server" />
        </div>
    </form>
</body>
</html>
