-- Thêm dữ liệu mẫu vào bảng Categories
use bookStoreManager_db
go

INSERT INTO Categories (Name, Description)
VALUES 
(N'Sách', N'Sách các loại bao gồm tiểu thuyết, giáo trình, ...'),
(N'Văn phòng phẩm', N'Dụng cụ học tập và văn phòng'),
(N'Đồ chơi', N'Đồ chơi cho trẻ em và người lớn'),
(N'Trò chơi giải trí', N'Sản phẩm hỗ trợ giải trí như board game, cờ, ...');

-- Thêm dữ liệu mẫu vào bảng Suppliers
INSERT INTO Suppliers (Name, ContactInfo)
VALUES 
(N'Nhà xuất bản Kim Đồng', N'Email: kimdong@publisher.com, Phone: 0909123456'),
(N'Nhà xuất bản Giáo dục Việt Nam', N'Email: giaoduc@publisher.com, Phone: 0909876543');

-- Thêm dữ liệu mẫu vào bảng Products
INSERT INTO Products (Name, Description, Price, CategoryID)
VALUES 
(N'Tiểu thuyết Sherlock Holmes', N'Truyện trinh thám nổi tiếng', 150000, 1),
(N'Bút bi Thiên Long', N'Bút bi cao cấp', 5000, 2),
(N'Rubik 3x3', N'Đồ chơi giải trí logic', 70000, 3),
(N'Cờ vua gỗ', N'Sản phẩm giải trí trí tuệ', 120000, 4);

-- Thêm dữ liệu mẫu vào bảng ProductImage
INSERT INTO ProductImage (ProductID, Url, IndexImg)
VALUES 
(1, 'https://example.com/sherlock.jpg',1),
(2, 'https://example.com/pen.jpg',1),
(3, 'https://example.com/rubik.jpg',1),
(4, 'https://example.com/chess.jpg',1);

-- Thêm dữ liệu mẫu vào bảng Inventory
INSERT INTO Inventory (ProductID, StockLevel, ReorderLevel)
VALUES 
(1, 100, 20),
(2, 500, 100),
(3, 200, 50),
(4, 150, 30);

-- Thêm dữ liệu mẫu vào bảng Authors
INSERT INTO Authors (FirstName, LastName, Bio, DateOfBirth)
VALUES 
(N'Arthur', N'Conan Doyle', N'Tác giả nổi tiếng người Anh', '1859-05-22'),
(N'Nguyễn Nhật', N'Ánh', N'Tác giả nổi tiếng người Việt', '1955-08-07');

-- Thêm dữ liệu mẫu vào bảng Books
INSERT INTO Books (BookID, ISBN, Publisher, PublishYear, PageCount)
VALUES 
(1, '978-604-56-4623-5', N'Kim Đồng', 2023, 350);

-- Thêm dữ liệu mẫu vào bảng BookAuthors
INSERT INTO BookAuthors (BookID, AuthorID, Role)
VALUES 
(1, 1, N'Tác giả chính');

-- Thêm dữ liệu mẫu vào bảng Customers
INSERT INTO Customers (FullName, Phone, Address_Line, City, Province)
VALUES 
(N'Nguyễn Văn A', '0909123456', N'123 đường ABC', N'Hà Nội', N'Hà Nội'),
(N'Lê Thị B', '0909876543', N'456 đường DEF', N'Hồ Chí Minh', N'Hồ Chí Minh');

-- Thêm dữ liệu mẫu vào bảng Orders
INSERT INTO Orders (CustomerID, Discount, Payment_Method, TotalAmount, Note)
VALUES 
(1, 10, N'Tiền mặt', 145000, N'Đã thanh toán'),
(2, 20, N'Ví điện tử', 260000, N'Chưa thanh toán');

-- Thêm dữ liệu mẫu vào bảng OrderItems
INSERT INTO OrderItems (OrderID, ProductID, Quantity, CurrentPrice)
VALUES 
(1, 1, 1,1000),
(1, 2, 5,1000),
(2, 3, 2,1000),
(2, 4, 1,1000);

-- Thêm dữ liệu mẫu vào bảng RestockOrders
INSERT INTO RestockOrders (SupplierID, TotalAmount, Status)
VALUES 
(1, 1500000, N'Đã hoàn thành'),
(2, 700000, N'Đang xử lý');

-- Thêm dữ liệu mẫu vào bảng RestockItems
INSERT INTO RestockItems (RestockOrderID, ProductID, Quantity, UnitCost)
VALUES 
(1, 1, 100, 14000),
(2, 3, 50, 60000);

-- Thêm dữ liệu mẫu vào bảng Collections
INSERT INTO Collections (Name, Description)
VALUES 
(N'Bộ sưu tập trinh thám', N'Những cuốn sách trinh thám nổi tiếng');

-- Thêm dữ liệu mẫu vào bảng CollectionBooks
INSERT INTO CollectionBooks (CollectionID, BookID)
VALUES 
(1, 1);

-- Thêm dữ liệu mẫu vào bảng Users
INSERT INTO Users (username, first_name, last_name, email, sex, Role, password, phone, Salary, address_line, city, province)
VALUES 
('admin', N'Quản', N'Lý', 'admin@example.com', N'Nam', N'Admin', 'admin123', '0912345678', 30000000, N'1 đường ABC', N'Hà Nội', N'Hà Nội'),
('employee1', N'Nguyễn', N'Văn B', 'employee1@example.com', N'Nam', N'Nhân viên', 'password123', '0911123456', 15000000, N'2 đường DEF', N'Hồ Chí Minh', N'Hồ Chí Minh');
INSERT INTO Users (
    username, 
    urlImg,
    first_name, 
    last_name, 
    email, 
    old, 
    sex, 
    Role, 
    password, 
    salt, 
    phone, 
    Salary, 
    address_line, 
    city, 
    province
) 
VALUES (
    'duyanh', 
    NULL, 
    N'Vũ Nguyễn', 
    N'Duy Anh', 
    'duyanh@gmail.com', 
    '2004-10-18 00:00:00.000', 
    N'Nam', 
    N'Quản lý', 
    'EoM/ujEp+4g84vML6eCFLkQPI43zDsFkc3CydTfln/4=', 
    'lyvWMZFLqnBkqUJ6UT6KTg==', 
    '868828780', 
    12000000.00, 
    NULL, 
    NULL, 
    NULL
);