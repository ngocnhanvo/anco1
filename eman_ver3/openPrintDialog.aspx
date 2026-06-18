<%@ Page Language="C#" EnableSessionState="ReadOnly" %>
<html lang="vi">
<head>
    <meta charset="utf-8" />
    <title>Đang tải dữ liệu...</title>
    <style type="text/css">
        .loading-overlay {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0, 0, 0, 0.4); /* Số 0.4 là độ đậm nhạt của lớp che */
            z-index: 99999; /* Đảm bảo luôn nằm trên cùng mọi phần tử */
            display: flex;
            justify-content: center;
            align-items: center;
            font-family: Arial, sans-serif;
        }

        .loading-box {
            text-align: center;
            color: #ffffff;
        }

        .spinner {
            margin: 0 auto 15px auto;
            width: 50px;
            height: 50px;
            border: 5px solid rgba(255, 255, 255, 0.3); /* Vòng viền mờ phía dưới */
            border-radius: 50%;
            border-top-color: #0078d4; /* Màu xanh của thanh xoay chính */
            animation: spin 1s ease-in-out infinite; /* Chạy vô hạn */
        }

        @keyframes spin {
            to {
                transform: rotate(360deg);
            }
        }
    </style>
</head>
<body style="display: flex; justify-content: center; align-items: center; height: 100vh; margin: 0; font-family: sans-serif;">
    <div id="loading-overlay" class="loading-overlay">
        <div class="loading-box">
            <div class="spinner"></div>
            <p>Vui lòng đợi trong giây lát...</p>
        </div>
    </div>
</body>
</html>