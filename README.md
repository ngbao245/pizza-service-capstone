# 🍕 OpsLink - Service Link System to enhance operations in Pizza restaurant

## 🧩 Tổng quan

**Tên dự án:**  
**English:** Service Link System to Enhance Operations in Pizza Restaurant  
**Vietnamese:** Hệ thống liên kết phục vụ trong nhà hàng Pizza  
**Abbreviation:** OpsLink

**Mục tiêu dự án:**  
OpsLink là hệ thống thông minh hỗ trợ vận hành toàn diện cho nhà hàng Pizza, bao gồm khách hàng, nhân viên phục vụ, đầu bếp và quản lý. Hệ thống giúp giảm sai sót, tối ưu thời gian phục vụ và nâng cao trải nghiệm khách hàng thông qua các giải pháp công nghệ hiện đại như đặt món qua QR, thông báo real-time, và quản lý nhân sự trực quan.

---

## 🌐 Các hệ thống thành phần và demo

| Thành phần | Miêu tả | Liên kết | Hình ảnh Demo |
|-----------|---------|----------|----------------|
| **Customer Web** | Web khách hàng quét mã QR, đặt món, theo dõi đơn hàng | [Customer](https://pizzacapstone.io.vn/) | *(Chèn hình tại đây)* |
| **QR Scanner (Pizza Service)** | Dịch vụ QR scanner cho khách đặt món nhanh chóng | [Pizza Service QR](https://pizza-user.vercel.app/qr-scanner) | *(Chèn hình tại đây)* |
| **Manager Web** | Giao diện quản lý menu, bàn ăn, khu vực và nhân sự | [Manager](https://pizza-manager-2025.vercel.app/) | *(Chèn hình tại đây)* |
| **Chef Web** | Giao diện bếp xem món, đánh dấu hoàn tất | [Chef](https://service-chef.vercel.app/) | *(Chèn hình tại đây)* |
| **Staff Mobile** | Ứng dụng di động cho nhân viên phục vụ | [Staff App (GitHub)](https://github.com/MeoKool/Capstone-project-order-pizza-staff) | *(Chèn hình tại đây)* |

---

## 🚀 Tính năng nổi bật

### 👨‍🍳 Đối với Khách hàng:
- Quét QR để xem menu và đặt món
- Theo dõi trạng thái đơn hàng theo thời gian thực
- Yêu cầu phục vụ, gọi thanh toán qua website trên điện thoại
- Đánh giá nhà hàng, xem voucher khuyến mãi, và đặt lịch workshop

### 👨‍💼 Đối với Nhân viên phục vụ:
- Tạo mã QR động, kích hoạt bàn khi có khách
- Nhận thông báo gọi phục vụ, hỗ trợ chia hóa đơn
- Theo dõi ca làm việc, tình trạng bàn ăn và khu vực workshop
- Đăng ký lịch làm việc, đổi lịch với nhân viên khác
- Xem lịch làm việc được phân công

### 👨‍🍳 Đối với Đầu bếp:
- Nhận và xử lý đơn hàng
- Đánh dấu hoàn tất, từ chối đơn hợp lệ
- Quản lý nguyên liệu theo lịch workshop
- Xem và quản lý lịch làm việc theo ca
- Nhận phân công chuẩn bị nguyên liệu cho workshop

### 📊 Đối với Quản lý:
- Quản lý bàn ăn, khu vực và nhân viên
- Quản lý menu các món ăn và combo
- Theo dõi hiệu suất nhân viên, thời gian phục vụ
- Quản lý lịch làm việc trực quan
- Tự đồng phân ca hằng tuần cho nhân viên và đầu bếp
- Sắp xếp nhân viên phục vụ theo từng ca làm việc
- Theo dõi và quản lý nhân viên theo khu vực theo thời gian thực

---

## ⚙️ Kiến trúc hệ thống và công nghệ sử dụng

- **Frontend:** React Typescript
- **Backend:** .NET 8 (C#)
- **Database:** Microsoft SQL Server (MSSQL)
- **Mobile:** Android (React Native)
- **Real-time:** SignalR / WebSocket
- **Quản lý mã nguồn:** GitHub
- **Quản lý dự án:** Trello

---

## 🔐 Yêu cầu phi chức năng

- Bảo mật: Mã hóa dữ liệu, xác thực người dùng bằng OTP
- Trực quan: Hiển thị rõ ràng thông tin món ăn và yêu cầu đặc biệt

---

## 📄 Tài liệu kèm theo

- SRS – Software Requirement Specification
- Architecture & Detailed Design
- User Guide & Installation Guide
- Test Plan & Test Report
- Source code & Hướng dẫn deploy

---

## 📸 Demo hình ảnh

### 🔹 Customer Web
*(Chèn ảnh tại đây)*

### 🔹 QR Scanner
*(Chèn ảnh tại đây)*

### 🔹 Manager Web
*(Chèn ảnh tại đây)*

### 🔹 Chef Web
*(Chèn ảnh tại đây)*

### 🔹 Staff Mobile
*(Chèn ảnh tại đây)*

---

## 📦 Cách triển khai

> Cấu hình DB, kết nối API, các bước cài đặt và khởi chạy dịch vụ sẽ được cập nhật chi tiết trong Installation Guide sắp tới.

---

## 👨‍💻 Thành viên thực hiện

| Họ và tên              | Vai trò   |
|------------------------|-----------|
| Trương Sỹ Quảng        | FrontEnd  |
| Vũ Nhật Hào            | BackEnd   |
| Nguyễn Hoàng Bảo       | BackEnd   |
| Nguyễn Hưng Hảo        | BackEnd   |
| Tống Trường Thanh      | FrontEnd  |

---

## 🏁 Kết quả mong đợi

- Tăng độ chính xác đơn hàng
- Giảm thời gian phục vụ
- Nâng cao sự hài lòng và trải nghiệm của khách hàng
- Cải thiện năng suất và sự phối hợp của nhân viên

---

## 📬 Liên hệ

Nếu bạn muốn biết thêm chi tiết về hệ thống hoặc có đề xuất cải tiến, vui lòng liên hệ qua GitHub hoặc email nhóm phát triển.
- 📧 Email: [ng.hoangbao03@gmail.com](mailto:ng.hoangbao03@gmail.com)


