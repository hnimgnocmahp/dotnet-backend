# Cài đặt MySQL 8.0.36 với Docker và cấu hình môi trường

## 1. Tải và chạy MySQL bằng Docker
### Tải image MySQL 8.0.36 (Debian) từ Docker Hub
    docker pull mysql:8.0.36-debian
### Chạy container MySQL
    ocker run --name mysql-8.0.36 -p 3306:3306 -e MYSQL_ROOT_PASSWORD=root -d mysql:8.0.36-debian

## 2. Cấu hình biến môi trường (.NET)
### Issuer cho JWT
    setx Jwt__Issuer "MyApp"
### Audience cho JWT
    setx Jwt__Audience "myusers"
### Secret key dùng để ký JWT
    setx Jwt__Key "Hjfslj43J3Gk+f2laj9Dfpl1qkR4iOkXw6pU+6q7lAA="
### Chuỗi kết nối MySQL
    setx ConnectionStrings__DefaultConnection "server=localhost;port=3306;database=store_management;user=root;password=root"

## 3. Kết nối database
Host: localhost
Port: 3306
User: root
Password: root
Database: store_management

## 4. Chạy chương trình
    1. cd vào thư mục Api
    2. chạy câu lệnh "dotnet run" hoặc "dotnet watch run"
