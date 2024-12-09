use master
go
drop database if EXISTS bookStoreManager_db
go
Create database bookStoreManager_db;
go
use bookStoreManager_db;
go

-- Tạo bảng loại sản phẩm
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
	description Nvarchar(500),
);

-- Tạo bảng thông tin sản phẩm chung
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(1000),
    Price DECIMAL(10, 2) NOT NULL,
	--Stock INT NOT NULL DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
	CategoryID int,
	foreign key (categoryID) references Categories(CategoryID) ON DELETE SET NULL
);

-- tạo bảng ảnh của sản phẩm
Create table ProductImage(
IndexImg int,
productID int FOREIGN KEY REFERENCES Products(ProductID) ON DELETE CASCADE,
primary key (indexImg,productID),
url varchar(255),
)

-- Tạo bảng lưu thông tin nhà cung cấp
CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    ContactInfo NVARCHAR(500)
);


-- Bảng phiếu nhập hàng
CREATE TABLE RestockOrders (
    RestockOrderID INT PRIMARY KEY IDENTITY(1,1),
    SupplierID INT, -- Nhà cung cấp liên quan đến nhập hàng
    RestockDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10, 2),
    Status NVARCHAR(50),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID) ON DELETE SET NULL
);

-- Bảng sản phẩm trong phiếu nhập hàng
CREATE TABLE RestockItems (
    RestockItemID INT PRIMARY KEY IDENTITY(1,1),
    RestockOrderID INT FOREIGN KEY REFERENCES RestockOrders(RestockOrderID) ON DELETE CASCADE,
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID) ON DELETE SET NULL,
    Quantity INT NOT NULL,
    UnitCost DECIMAL(10, 2) NOT NULL
);


-- Tạo bảng lưu thông tin tác giả
CREATE TABLE Authors (
    AuthorID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Bio NVARCHAR(1000) NULL,
    DateOfBirth DATE NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);

-- Tạo bảng sách
CREATE TABLE Books (
    BookID INT PRIMARY KEY,
    ISBN NVARCHAR(20) UNIQUE,
    Publisher NVARCHAR(255),
    PublishYear INT,
    PageCount INT,
    FOREIGN KEY(bookID) REFERENCES Products(ProductID) ON DELETE CASCADE
);

-- Tạo bảng liên kết các tác giả với sách
CREATE TABLE BookAuthors (
    BookID INT NOT NULL,
    AuthorID INT NOT NULL,
    Role NVARCHAR(100) NULL, -- Vai trò của tác giả : tác giả chính, ...
    CreatedAt DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (BookID, AuthorID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID) ON DELETE CASCADE,
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID) ON DELETE CASCADE,
);
 

-- Tạo bảng bộ sưu tập
CREATE TABLE Collections (
    CollectionID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(1000),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Tạo bảng lưu sách có trong bộ sưu tập
CREATE TABLE CollectionBooks (
    CollectionID INT FOREIGN KEY REFERENCES Collections(CollectionID),
    BookID INT FOREIGN KEY REFERENCES Books(BookID)  ON DELETE CASCADE,
    PRIMARY KEY (CollectionID, BookID)
);


-- Tạo bảng người dùng
CREATE TABLE Users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
	urlImg varchar(255),
    first_name NVARCHAR(30),
    last_name NVARCHAR(30),
    email VARCHAR(100),
	old dateTime default getdate(),
	sex Nvarchar(30) check (sex in(N'Nam',N'Nữ',N'Khác')) not null,
	Role NVARCHAR(100) check (Role in (N'Quản lý', N'Nhân viên', N'Admin')) not null,
    password VARCHAR(255) NOT NULL,
	salt varchar(255),
    phone VARCHAR(15),
	Salary DECIMAL(15, 2) NOT NULL default 0, 
    address_line NVARCHAR(200),
    city NVARCHAR(50),
    province NVARCHAR(50),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);

--CREATE TABLE Salaries (
--    SalaryID INT PRIMARY KEY IDENTITY(1,1),
--    UserID INT NOT NULL,
--    Salary DECIMAL(10, 2) NOT NULL,  -- Lương hàng tháng
--    EffectiveDate DATE NOT NULL,     -- Ngày bắt đầu hiệu lực của mức lương này
--    FOREIGN KEY (UserID) REFERENCES Users(user_id) ON DELETE CASCADE
--);

-- Tạo bảng khách hàng
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
	FullName  Nvarchar(50),
	phone VARCHAR(15),
    address_line NVARCHAR(200),
    city NVARCHAR(50),
    province NVARCHAR(50),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    LoyaltyPoints INT DEFAULT 0
);


-- Tạo bảng quản lý đơn hàng
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    OrderDate DATETIME DEFAULT GETDATE(),
	Discount DECIMAL(5, 2) DEFAULT 0,
	payment_method NVARCHAR(50) NOT NULL CHECK (payment_method IN (N'Thẻ tín dụng', N'Ví điện tử', N'Chuyển khoản',N'Tiền mặt')),
    TotalAmount DECIMAL(12, 2),
    Note NVARCHAR(200),
	FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID) ON DELETE SET NULL
);


-- Tạo bảng sản phẩm bên trong đơn hàng
CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID) ON DELETE CASCADE,
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID) ON DELETE SET NULL,
    Quantity INT NOT NULL,
	CurrentPrice decimal(10,2),
);


-- T?o b?ng Employee đ? qu?n l? nhân viên

-- Tạo bảng lưu số lượng tồn kho
CREATE TABLE Inventory (
    ProductID INT PRIMARY KEY FOREIGN KEY REFERENCES Products(ProductID) ON DELETE CASCADE,
    StockLevel INT NOT NULL default 0,
   ReorderLevel INT NOT NULL
);

-- Tạo bảng thể loại của sách
CREATE TABLE BookGenres (
    GenreID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL
);

-- Tạo bảng liên kết thể loại và sách
CREATE TABLE BookGenreMappings (
    BookID INT FOREIGN KEY REFERENCES Books(BookID)  ON DELETE CASCADE,
    GenreID INT FOREIGN KEY REFERENCES BookGenres(GenreID),
    PRIMARY KEY (BookID, GenreID)
);

-- cập nhật tồn kho sau khi nhập hàng
go
CREATE TRIGGER trg_UpdateStockOnRestock
ON RestockItems
AFTER INSERT
AS
BEGIN
    UPDATE Inventory
    SET StockLevel = StockLevel + inserted.Quantity
    FROM Inventory
    INNER JOIN inserted ON Inventory.ProductID = inserted.ProductID;
END;

-- cập nhật tồn kho sau khi ban
go
CREATE TRIGGER trg_UpdateStock_AfterSale
ON OrderItems
AFTER INSERT , update
AS
BEGIN
    UPDATE Inventory
    SET StockLevel = StockLevel - inserted.Quantity
    FROM Inventory
    INNER JOIN inserted ON Inventory.ProductID = inserted.ProductID;
    
    -- Kiểm tra số lượng tồn kho sau khi bán để phát cảnh báo nếu dưới mức reorder level
    IF EXISTS (
        SELECT 1
        FROM Inventory
        WHERE StockLevel < ReorderLevel
    )
    BEGIN
        PRINT 'Cảnh báo: Một hoặc nhiều sản phẩm đã dưới mức tồn kho tối thiểu.';
    END
END;
go
--tính giá tiền khi nhập hàng
CREATE TRIGGER trg_CalculateRestockTotal
ON RestockItems
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    UPDATE RestockOrders
    SET TotalAmount = (
        SELECT SUM(Quantity * UnitCost)
        FROM RestockItems
        WHERE RestockItems.RestockOrderID = RestockOrders.RestockOrderID
    )
    WHERE RestockOrders.RestockOrderID IN (SELECT DISTINCT RestockOrderID FROM inserted UNION SELECT DISTINCT RestockOrderID FROM deleted);
END;

go
CREATE TRIGGER trg_CalculateOrderTotal
ON OrderItems
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    UPDATE Orders
    SET TotalAmount = (
        SELECT SUM(Quantity * Products.Price)
        FROM OrderItems
        INNER JOIN Products ON OrderItems.ProductID = Products.ProductID
        WHERE OrderItems.OrderID = Orders.OrderID
    ) - Orders.Discount  -- Trừ đi giá trị giảm giá
    WHERE Orders.OrderID IN (SELECT DISTINCT OrderID FROM inserted UNION SELECT DISTINCT OrderID FROM deleted);
END;


go





-- tạo trigger dể tính giá tiền trong order






--Cập nhật sản phẩm
-- Cập nhật sản phẩm
CREATE PROCEDURE UpdateProductInfo
    @ProductID INT,
    @ProductName NVARCHAR(255),
    @CategoryName NVARCHAR(255),
    @StockLevel INT,
    @Price DECIMAL(10, 2),
    @desc NVARCHAR(1000)
AS
BEGIN
    DECLARE @CategoryID INT;
    DECLARE @IsBook BIT;

    -- Lấy CategoryID dựa trên tên loại sản phẩm
    SELECT @CategoryID = CategoryID
    FROM Categories
    WHERE Name = @CategoryName;

    -- Kiểm tra xem loại sản phẩm có phải là sách không
    IF @CategoryName = 'Sách'
    BEGIN
        SET @IsBook = 1;
    END
    ELSE
    BEGIN
        SET @IsBook = 0;
    END

    -- Cập nhật thông tin sản phẩm trong bảng Products
    UPDATE Products
    SET Name = @ProductName,
        Price = @Price,
        CategoryID = @CategoryID,
        Description = @desc,
        UpdatedAt = GETDATE()
    WHERE ProductID = @ProductID;

    -- Cập nhật tồn kho trong bảng Inventory
    UPDATE Inventory
    SET StockLevel = @StockLevel
    WHERE ProductID = @ProductID;

    -- Nếu sản phẩm không phải là sách, kiểm tra và xóa thông tin sách trong bảng Books
    IF @IsBook = 0
    BEGIN
        -- Kiểm tra sản phẩm có thuộc bảng Books không
        IF EXISTS (SELECT 1 FROM Books WHERE BookID = @ProductID)
        BEGIN
            -- Xóa thông tin sách nếu có
            DELETE FROM Books WHERE BookID = @ProductID;
        END
    END

    -- Trả về thời gian cập nhật của sản phẩm
    SELECT UpdatedAt AS LastUpdated
    FROM Products
    WHERE ProductID = @ProductID;
END;
go

create PROCEDURE UpdateProductImages
    @ProductID INT,               -- ID của sản phẩm cần cập nhật
    @ImageURLs NVARCHAR(MAX)      -- Danh sách URL hình ảnh, phân cách bởi dấu phẩy
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem sản phẩm có tồn tại không
    IF NOT EXISTS (SELECT 1 FROM Products WHERE ProductID = @ProductID)
    BEGIN
        THROW 50001, 'Product does not exist.', 1;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Xóa các hình ảnh cũ liên quan đến sản phẩm
        DELETE FROM ProductImage WHERE ProductID = @ProductID;

        -- Chia danh sách URL hình ảnh (SQL Server 2016+ sử dụng STRING_SPLIT)
        DECLARE @Index INT = 1;

        -- Dùng STRING_SPLIT để chia danh sách URL
        DECLARE @URL NVARCHAR(255);
        DECLARE @URLList TABLE (URL NVARCHAR(255));

        -- Chèn các URL vào bảng tạm
        INSERT INTO @URLList (URL)
        SELECT value
        FROM STRING_SPLIT(@ImageURLs, ',');

        -- Thêm các hình ảnh vào bảng ProductImage
        DECLARE cur CURSOR FOR
        SELECT URL FROM @URLList;

        OPEN cur;
        FETCH NEXT FROM cur INTO @URL;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Thêm URL vào bảng ProductImage
            INSERT INTO ProductImage (IndexImg, ProductID, URL)
            VALUES (@Index, @ProductID, @URL);

            -- Tăng chỉ số hình ảnh
            SET @Index = @Index + 1;

            FETCH NEXT FROM cur INTO @URL;
        END

        CLOSE cur;
        DEALLOCATE cur;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW 50002, 'An error occurred while updating product images: ', 1;
    END CATCH;
END


go

--thêm đơn hàng mwói
Create PROCEDURE AddOrder
    @CustomerID INT = NULL, -- Nếu không có, gán mặc định là NULL
    @PaymentMethod NVARCHAR(50),
    @Discount DECIMAL(10, 2),
    @TotalAmount DECIMAL(10, 2),
    @Note NVARCHAR(50)
AS
BEGIN
    BEGIN TRY
        -- Kiểm tra và thêm khách lẻ nếu CustomerID không được cung cấp
        IF @CustomerID IS NULL
        BEGIN
            -- Đảm bảo khách lẻ đã tồn tại hoặc tạo mới nếu chưa có
            DECLARE @DefaultCustomerID INT;
            SELECT @DefaultCustomerID = CustomerID 
            FROM Customers 
            WHERE FullName = N'Khách lẻ';

            IF @DefaultCustomerID IS NULL
            BEGIN
                INSERT INTO Customers (FullName)
                VALUES (N'Khách lẻ');

                SET @DefaultCustomerID = SCOPE_IDENTITY(); -- Lấy ID của khách lẻ vừa thêm
            END

            SET @CustomerID = @DefaultCustomerID; -- Gán ID của khách lẻ
        END

        -- Thêm đơn hàng mới
        INSERT INTO Orders (CustomerID, Discount, Payment_Method, TotalAmount, Note)
        VALUES (@CustomerID, @Discount, @PaymentMethod, @TotalAmount, @Note);

        -- Lấy ID của đơn hàng vừa thêm
        DECLARE @OrderID INT = SCOPE_IDENTITY();

        -- Trả về bảng chứa CustomerID và OrderID
        SELECT 
            @CustomerID AS CustomerID,
            @OrderID AS OrderID;
    END TRY
    BEGIN CATCH
        -- Xử lý lỗi
        THROW;
    END CATCH
END;

--EXEC AddOrder     @CustomerID = NULL, -- Không có khách hàng cụ thể    @PaymentMethod = N'Tiền mặt',    @Discount = 10,    @TotalAmount = 500000,    @Note = N'Khách lẻ mua hàng';



go
--thêm sản phẩm mới vào đơn hàng
CREATE PROCEDURE AddOrderItem
    @OrderID INT,
    @ProductID INT,
    @Quantity INT,
	@price decimal(10,2)
AS
BEGIN
    INSERT INTO OrderItems (OrderID, ProductID, Quantity, CurrentPrice)
    VALUES (@OrderID, @ProductID, @Quantity, @price);
END;

--EXEC AddOrderItem @OrderID = 1, @ProductID = 1, @Quantity = 2, @price = 50.00;

go
--gán thể loại cho sách
CREATE PROCEDURE AssignGenreToBook
    @BookID INT,
    @GenreID INT
AS
BEGIN
    INSERT INTO BookGenreMappings (BookID, GenreID)
    VALUES (@BookID, @GenreID);
END;

go
--cập nhật hàng tồn kho
CREATE PROCEDURE UpdateStock
    @ProductID INT,
    @StockLevel INT
AS
BEGIN
    UPDATE Inventory
    SET StockLevel = @StockLevel
    WHERE ProductID = @ProductID;
END;

go
--kiểm tra hàng tồn kho
CREATE view CheckLowStock
AS
    SELECT p.Name, i.StockLevel
    FROM Inventory i
    INNER JOIN Products p ON i.ProductID = p.ProductID
    WHERE i.StockLevel < i.ReorderLevel;
;

go
--báo cáo thông kê
CREATE PROCEDURE GetDailyRevenue
    @Date DATE
AS
BEGIN
    SELECT SUM(o.TotalAmount) AS DailyRevenue
    FROM Orders o
    WHERE CAST(o.OrderDate AS DATE) = @Date;
END;

go
--thêm khách hàng mới
CREATE PROCEDURE AddCustomer
    @FullName NVARCHAR(50),
    @Phone VARCHAR(15),
    @AddressLine NVARCHAR(200),
    @City NVARCHAR(50),
    @Province NVARCHAR(50)
AS
BEGIN
    INSERT INTO Customers (FullName, Phone, Address_Line, City, Province)
    VALUES (@FullName, @Phone, @AddressLine, @City, @Province);
END;

go
-- Tạo thủ tục để cập nhật thông tin khách hàng
CREATE PROCEDURE UpdateCustomer
    @CustomerID INT,                -- ID của khách hàng cần cập nhật
    @FullName NVARCHAR(50) = NULL,   -- Tên khách hàng, có thể NULL nếu không muốn cập nhật
    @Phone VARCHAR(15) = NULL,       -- Số điện thoại khách hàng, có thể NULL nếu không muốn cập nhật
    @AddressLine NVARCHAR(200) = NULL, -- Địa chỉ khách hàng, có thể NULL nếu không muốn cập nhật
    @City NVARCHAR(50) = NULL,       -- Thành phố, có thể NULL nếu không muốn cập nhật
    @Province NVARCHAR(50) = NULL,   -- Tỉnh, có thể NULL nếu không muốn cập nhật
    @LoyaltyPoints INT = NULL        -- Điểm khách hàng, có thể NULL nếu không muốn cập nhật
AS
BEGIN
    -- Cập nhật thông tin khách hàng theo @CustomerID
    UPDATE Customers
    SET 
        FullName = CASE WHEN @FullName IS NOT NULL THEN @FullName ELSE FullName END,
        Phone = CASE WHEN @Phone IS NOT NULL THEN @Phone ELSE Phone END,
        address_line = CASE WHEN @AddressLine IS NOT NULL THEN @AddressLine ELSE address_line END,
        City = CASE WHEN @City IS NOT NULL THEN @City ELSE City END,
        Province = CASE WHEN @Province IS NOT NULL THEN @Province ELSE Province END,
        LoyaltyPoints = CASE WHEN @LoyaltyPoints IS NOT NULL THEN @LoyaltyPoints ELSE LoyaltyPoints END,
        updated_at = GETDATE() -- Cập nhật thời gian sửa đổi
    WHERE CustomerID = @CustomerID;
END;
GO
-- Tạo View để hiển thị thông tin về các sản phẩm, bao gồm tên sản phẩm, mô tả, giá, và tên danh mục.
CREATE VIEW vw_ProductDetails AS
SELECT 
    p.ProductID,
    p.Name AS ProductName,
    p.Description AS ProductDescription,
    p.Price AS ProductPrice,
    c.Name AS CategoryName,
    p.CreatedAt,
    p.UpdatedAt
FROM Products p
JOIN Categories c ON p.CategoryID = c.CategoryID;

GO

-- Tạo View để hiển thị thông tin khách hàng, bao gồm tên, số điện thoại, địa chỉ, thành phố, tỉnh và điểm trung thành.
CREATE VIEW vw_CustomerDetails AS
SELECT 
    c.CustomerID,
    c.FullName,
    c.Phone,
    c.address_line,
    c.City,
    c.Province,
    c.LoyaltyPoints
FROM Customers c;
GO

-- Tạo View để hiển thị thông tin đơn hàng, bao gồm mã đơn hàng, tên khách hàng, ngày đặt hàng, tổng giá trị và trạng thái đơn hàng.
CREATE VIEW vw_OrderDetails AS
SELECT 
    o.OrderID,
    o.OrderDate,
    o.TotalAmount,
    o.Note,
    c.FullName AS CustomerName,
    c.Phone AS CustomerPhone,
    c.address_line AS CustomerAddress
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID;
GO

-- Tạo View để hiển thị thông tin các mặt hàng trong đơn hàng, bao gồm mã sản phẩm, tên sản phẩm, số lượng và đơn giá.
CREATE PROCEDURE vw_OrderItemsDetails
@orderID int
AS
SELECT 
    oi.OrderItemID,
    oi.OrderID,
    oi.ProductID,
    p.Name AS ProductName,
    oi.Quantity,
    p.Price AS ProductPrice,
    oi.Quantity * p.Price AS TotalPrice
FROM OrderItems oi
JOIN Products p ON oi.ProductID = p.ProductID
where oi.orderID = @orderID;
GO

-- Tạo View để hiển thị thông tin phiếu nhập hàng, bao gồm mã phiếu nhập, nhà cung cấp, tổng số lượng và tổng giá trị nhập hàng.
CREATE VIEW vw_RestockOrderDetails AS
SELECT 
    ro.RestockOrderID,
    ro.RestockDate,
    ro.TotalAmount,
    ro.Status,
    s.Name AS SupplierName,
    s.ContactInfo AS SupplierContactInfo
FROM RestockOrders ro
JOIN Suppliers s ON ro.SupplierID = s.SupplierID;
GO

-- Tạo View để hiển thị chi tiết các mặt hàng trong phiếu nhập hàng, bao gồm mã sản phẩm, tên sản phẩm, số lượng nhập và giá nhập.
CREATE VIEW vw_RestockItemDetails AS
SELECT 
    ri.RestockItemID,
    ri.RestockOrderID,
    ri.ProductID,
    p.Name AS ProductName,
    ri.Quantity AS QuantityRestocked,
    ri.UnitCost AS UnitCost,
    ri.Quantity * ri.UnitCost AS TotalCost
FROM RestockItems ri
JOIN Products p ON ri.ProductID = p.ProductID;
GO

-- Tạo View để hiển thị thông tin tác giả và sách mà tác giả đó viết, bao gồm tên tác giả, tên sách và vai trò của tác giả.
CREATE VIEW vw_AuthorBookDetails AS
SELECT 
    a.AuthorID,
    a.FirstName + N' ' + a.LastName AS AuthorName,
    b.BookID,
    b.ISBN,
    b.Publisher,
    b.PublishYear,
    ba.Role AS AuthorRole
FROM BookAuthors ba
JOIN Authors a ON ba.AuthorID = a.AuthorID
JOIN Books b ON ba.BookID = b.BookID;
GO

-- Tạo View để hiển thị thông tin bộ sưu tập và các sách trong bộ sưu tập, bao gồm tên bộ sưu tập, mô tả và tên sách.
-- Tạo View để hiển thị thông tin kho, bao gồm mã sản phẩm, tên sản phẩm, số lượng tồn kho và mức độ tái nhập.
CREATE VIEW vw_InventoryDetails AS
SELECT 
    i.ProductID,
    p.Name AS ProductName,
    i.StockLevel,
    i.ReorderLevel
FROM Inventory i
JOIN Products p ON i.ProductID = p.ProductID;
GO

-- Tạo View để hiển thị thông tin sản phẩm và thể loại sách của nó, bao gồm tên sản phẩm và tên thể loại.
CREATE VIEW vw_ProductGenreDetails AS
SELECT 
    p.ProductID,
    p.Name AS ProductName,
    g.Name AS GenreName
FROM BookGenreMappings bgm
JOIN Products p ON bgm.BookID = p.ProductID
JOIN BookGenres g ON bgm.GenreID = g.GenreID;
GO

create PROCEDURE getProducts
    @sl INT,
    @CategoryID INT = NULL
AS
BEGIN
    SELECT 
		-- Lấy hình ảnh đầu tiên của sản phẩm (nếu có)
        (SELECT TOP 1 url FROM ProductImage WHERE ProductID = Products.ProductID) AS ProductImage,
        Products.ProductID, 
        Products.Name, 
        Price, 
        StockLevel, 
        Categories.Name AS CategoryName
        
    FROM Products
    JOIN Categories ON Products.CategoryID = Categories.CategoryID
    LEFT JOIN Inventory ON Products.ProductID = Inventory.ProductID
    WHERE (@CategoryID IS NULL OR Products.CategoryID = @CategoryID)
    -- Thêm điều kiện để chỉ lấy số lượng sản phẩm theo tham số @sl
    ORDER BY Products.ProductID
    OFFSET 0 ROWS FETCH NEXT @sl ROWS ONLY;  -- Giới hạn số lượng sản phẩm trả về theo tham số @sl
END;
GO


--exec getProducts @sl=10, @CategoryID =NULL go


-- Tạo View để hiển thị thông tin về các sản phẩm, bao gồm tên sản phẩm, mô tả, giá, và tên danh mục.
create PROCEDURE getProductDetails
@id INT
AS
BEGIN
    SELECT 
        p.ProductID,
        p.Name AS ProductName,
        p.Description AS ProductDescription,
        p.Price AS ProductPrice,
        c.Name AS CategoryName,
        i.StockLevel,  -- Lấy StockLevel từ bảng Inventory
        p.CreatedAt,
        p.UpdatedAt
    FROM Products p
    JOIN Categories c ON p.CategoryID = c.CategoryID
    JOIN Inventory i ON p.ProductID = i.ProductID  -- JOIN với bảng Inventory
    WHERE p.ProductID = @id
END
GO


-- exec getProductDetails @id = 1;

Create Procedure getListImgProduct
@id int
AS
SELECT url, IndexImg
FROM ProductImage 
where productID = @id
GO

-- exec getListImgProduct @id = 1;

Create Procedure getBookDetails
@id int
AS
SELECT 
	
	ISBN,
	Publisher,
	PublishYear,
	PageCount
FROM Books
where BookID = @id
GO

--exec getBookDetails @id = 1;

CREATE PROCEDURE getBookAuthors
    @id INT
AS
BEGIN
    SELECT 
        Authors.AuthorID,
        (Authors.FirstName + ' ' + Authors.LastName) AS Name,
        BookAuthors.Role
    FROM Authors
    INNER JOIN BookAuthors ON Authors.AuthorID = BookAuthors.AuthorID
    WHERE BookAuthors.BookID = @id;
END

--exec getBookAuthors @id =1;

go
create PROCEDURE updateProduct
    @ProductID INT,            -- ID sản phẩm cần cập nhật
    @name NVARCHAR(255),       -- Tên sản phẩm mới
    @price DECIMAL(10, 2),     -- Giá sản phẩm mới
    @desc NVARCHAR(1000)       -- Mô tả sản phẩm mới
AS
BEGIN
    -- Kiểm tra xem sản phẩm có tồn tại hay không
    IF EXISTS (SELECT 1 FROM Products WHERE ProductID = @ProductID)
    BEGIN
        -- Cập nhật thông tin sản phẩm
        UPDATE Products
        SET 
            Name = @name,
            Price = @price,
            Description = @desc,
            UpdatedAt = GETDATE() -- Tự động cập nhật ngày thay đổi
        WHERE ProductID = @ProductID;

        PRINT N'Cập nhật sản phẩm thành công!';
    END
    ELSE
    BEGIN
        PRINT N'Sản phẩm không tồn tại!';
    END
END;

--exec updateProduct @ProductID = 1, @name =N'12324', @price = 100, @desc = N'111'
go
CREATE PROCEDURE GetEmployeeInformation
AS
BEGIN
    SELECT 
        u.user_id AS Id,
        u.first_name + ' ' + u.last_name AS Name,
        u.Role,
        u.phone AS Phone,
        ISNULL(u.Salary, 0) AS Salary,  
        u.address_line AS Address
    FROM Users u
END;

--exec GetEmployeeInformation
--EXEC sp_help 'updateProduct';
go

CREATE PROCEDURE GetEmployeeById
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        user_id AS Id,
        first_name AS FirstName,
        last_name AS LastName,
        urlImg AS ImageUrl,
        email,
        phone,
		old,
        address_line AS AddressLine,
        city,
        province,
        Role
    FROM 
        Users
    WHERE 
        user_id = @UserId;
END;
GO


create PROCEDURE InsertUser
    @Username NVARCHAR(50),
    @UrlImg NVARCHAR(255),
    @FirstName NVARCHAR(30),
    @LastName NVARCHAR(30),
    @Email NVARCHAR(100),
    @Sex NVARCHAR(30),
    @Role NVARCHAR(100),
	@old datetime,
    @HashedPassword VARCHAR(255),
	@salt varchar(255),
    @Phone NVARCHAR(15),
    @Salary DECIMAL(15, 2),
    @AddressLine NVARCHAR(200),
    @City NVARCHAR(50),
    @Province NVARCHAR(50),
    @NewUserId INT OUTPUT -- Thêm tham số OUT để trả về ID mới
AS
BEGIN
    -- Thực hiện Insert
    INSERT INTO Users (
        username, urlImg, first_name, last_name, email,old, sex, Role, password,salt, phone, Salary, address_line, city, province
    )
    VALUES (
        @Username, @UrlImg, @FirstName, @LastName, @Email,@old, @Sex, @Role, @HashedPassword,@salt, @Phone, @Salary, @AddressLine, @City, @Province
    );

    -- Lấy ID mới vừa được tạo và gán vào tham số OUTPUT
    SET @NewUserId = SCOPE_IDENTITY();
END;
GO


create PROCEDURE UpdateUser
    @UserId INT,
    @Username VARCHAR(50),
    @UrlImg VARCHAR(255) = NULL,
    @FirstName NVARCHAR(30) = NULL,
    @LastName NVARCHAR(30) = NULL,
    @Email VARCHAR(100) = NULL,
	@old datetime,
    @Sex NVARCHAR(30),
    @Role NVARCHAR(100),
    @HashedPassword VARCHAR(255) = NULL, -- Mặc định NULL
	@salt varchar(255) = NULL,
    @Phone NVARCHAR(15) = NULL,
    @Salary DECIMAL(15, 2),
    @AddressLine NVARCHAR(200) = NULL,
    @City NVARCHAR(50) = NULL,
    @Province NVARCHAR(50) = NULL
AS
BEGIN
    BEGIN TRY
        IF @HashedPassword IS NOT NULL
        BEGIN
            -- Cập nhật tất cả các cột bao gồm mật khẩu
            UPDATE Users
            SET 
                Username = @Username,
                UrlImg = @UrlImg,
                first_name = @FirstName,
                last_name = @LastName,
                Email = @Email,
				old = @old,
                sex = @Sex,
                Role = @Role,
                password = @HashedPassword,
				salt = @salt,
                Phone = @Phone,
                Salary = @Salary,
                address_line = @AddressLine,
                City = @City,
                Province = @Province
            WHERE user_id = @UserId;
        END
        ELSE
        BEGIN
            -- Cập nhật tất cả các cột ngoại trừ mật khẩu
            UPDATE Users
            SET 
                Username = @Username,
                UrlImg = @UrlImg,
                first_name = @FirstName,
                last_name = @LastName,
                Email = @Email,
				old = @old,
                sex = @Sex,
                Role = @Role,
                Phone = @Phone,
                Salary = @Salary,
                address_line = @AddressLine,
                City = @City,
                Province = @Province
            WHERE user_id = @UserId;
        END

        RETURN 1; -- Thành công
    END TRY
    BEGIN CATCH
        -- Xử lý lỗi và trả về mã lỗi
        RETURN ERROR_NUMBER();
    END CATCH
END
GO

Create PROCEDURE GetUserById
@UserId INT
AS
BEGIN
    SELECT 
        user_id AS UserId,
        username AS Username,
        urlImg AS UrlImg,
        first_name AS FirstName,
        last_name AS LastName,
        email AS Email,
		old,
        sex AS Sex,
        Role AS Role,
        phone AS Phone,
        Salary,
        address_line AS AddressLine,
        city AS City,
        province AS Province
    FROM Users
    WHERE user_id = @UserId;
END;
GO

--exec GetUserById @UserId = 25;

CREATE PROCEDURE DeleteUserById
    @UserId INT
AS
BEGIN
    -- Kiểm tra xem user_id có tồn tại trong bảng Users không
    IF EXISTS (SELECT 1 FROM Users WHERE user_id = @UserId)
    BEGIN
        -- Xóa người dùng có user_id tương ứng
        DELETE FROM Users WHERE user_id = @UserId;

        -- Thông báo thành công
        PRINT 'Người dùng đã được xóa thành công.';
    END
    ELSE
    BEGIN
        -- Thông báo nếu không tìm thấy người dùng
        PRINT 'Không tìm thấy người dùng với ID đã cho.';
    END
END;
GO

--exec DeleteUserById @UserId = 4;

create PROCEDURE UpdateBookInfo
    @BookID INT,                 -- ID của sách cần cập nhật hoặc chèn mới
    @ISBN NVARCHAR(20),          -- ISBN của sách
    @Publisher NVARCHAR(255),    -- Nhà xuất bản
    @PublishYear INT,            -- Năm xuất bản
    @PageCount INT               -- Số trang
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Kiểm tra xem sách có tồn tại không
        IF EXISTS (SELECT 1 FROM Books WHERE BookID = @BookID)
        BEGIN
            -- Nếu tồn tại, cập nhật thông tin sách
            UPDATE Books
            SET ISBN = @ISBN,
                Publisher = @Publisher,
                PublishYear = @PublishYear,
                PageCount = @PageCount
            WHERE BookID = @BookID;

            PRINT 'Thông tin sách đã được cập nhật thành công.';
        END
        ELSE
        BEGIN
            -- Nếu không tồn tại, chèn một sách mới
            INSERT INTO Books (BookID, ISBN, Publisher, PublishYear, PageCount)
            VALUES (@BookID, @ISBN, @Publisher, @PublishYear, @PageCount);

            PRINT 'Thông tin sách mới đã được thêm thành công.';
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT 'Đã xảy ra lỗi khi cập nhật hoặc thêm thông tin sách.';
    END CATCH;
END;
GO



CREATE PROCEDURE DeleteAuthorsByBookID
    @BookID INT
AS
BEGIN
    -- Bắt đầu transaction (không bắt buộc, tùy trường hợp)
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Xóa tất cả các tác giả liên quan đến BookID
        DELETE FROM BookAuthors
        WHERE BookID = @BookID;

        -- Commit transaction
        COMMIT TRANSACTION;

        PRINT 'Authors deleted successfully.';
    END TRY
    BEGIN CATCH
        -- Rollback transaction nếu có lỗi
        ROLLBACK TRANSACTION;

        PRINT 'An error occurred while deleting authors.';
        THROW; -- Gửi lại lỗi
    END CATCH;
END;

--exec DeleteAuthorsByBookID @bookID = 1;


go

CREATE PROCEDURE UpdateBookAuthor
    @BookID INT,
    @AuthorName NVARCHAR(255),
    @Role NVARCHAR(255)
AS
BEGIN
    -- Biến để lưu ID tác giả
    DECLARE @AuthorID INT;

    -- Kiểm tra xem tác giả đã tồn tại trong bảng Authors chưa
    SELECT @AuthorID = AuthorID
    FROM Authors
    WHERE FirstName + ' ' + LastName = @AuthorName;

    -- Nếu tác giả không tồn tại, thêm mới vào bảng Authors
    IF @AuthorID IS NULL
    BEGIN
        INSERT INTO Authors (FirstName, LastName, CreatedAt, UpdatedAt)
        VALUES (
            LEFT(@AuthorName, CHARINDEX(' ', @AuthorName + ' ') - 1), -- FirstName
            RIGHT(@AuthorName, LEN(@AuthorName) - CHARINDEX(' ', @AuthorName + ' ')), -- LastName
            GETDATE(), 
            GETDATE()
        );

        -- Lấy ID tác giả vừa thêm vào
        SET @AuthorID = SCOPE_IDENTITY();
    END

    -- Cập nhật tác giả cho sách
    IF EXISTS (SELECT 1 FROM BookAuthors WHERE BookID = @BookID AND AuthorID = @AuthorID)
    BEGIN
        -- Nếu đã có tác giả này cho sách, cập nhật vai trò
        UPDATE BookAuthors
        SET Role = @Role
        WHERE BookID = @BookID AND AuthorID = @AuthorID;
    END
    ELSE
    BEGIN
        -- Nếu chưa có tác giả này cho sách, thêm mới vào bảng BookAuthors
        INSERT INTO BookAuthors (BookID, AuthorID, Role)
        VALUES (@BookID, @AuthorID, @Role);
    END
END

go
create PROCEDURE AddProduct
    @CategoryName NVARCHAR(255), -- Tên loại sản phẩm
    @Name NVARCHAR(255),
    @Description NVARCHAR(1000),
    @Price DECIMAL(10, 2),
    @StockLevel INT,
    @ReorderLevel INT,
    @ImageUrls NVARCHAR(MAX) -- Danh sách URL ảnh, ngăn cách bằng dấu phẩy
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Lấy CategoryID từ tên loại sản phẩm hoặc thêm mới nếu chưa tồn tại
        DECLARE @CategoryID INT;
        SELECT @CategoryID = CategoryID
        FROM Categories
        WHERE Name = @CategoryName;

        IF @CategoryID IS NULL
        BEGIN
            INSERT INTO Categories (Name)
            VALUES (@CategoryName);
            SET @CategoryID = SCOPE_IDENTITY();
        END;

        -- Thêm sản phẩm vào bảng Products
        DECLARE @NewProductID INT;
        INSERT INTO Products (Name, Description, Price, CategoryID, CreatedAt, UpdatedAt)
        VALUES (@Name, @Description, @Price, @CategoryID, GETDATE(), GETDATE());

        SET @NewProductID = SCOPE_IDENTITY();

        -- Thêm ảnh vào bảng ProductImage
        IF (@ImageUrls IS NOT NULL AND LEN(@ImageUrls) > 0)
        BEGIN
            DECLARE @Url NVARCHAR(255);
            DECLARE @Index INT = 1;

            -- Tách danh sách URL ảnh và thêm vào bảng ProductImage
            WHILE CHARINDEX(',', @ImageUrls) > 0
            BEGIN
                SET @Url = LTRIM(RTRIM(SUBSTRING(@ImageUrls, 1, CHARINDEX(',', @ImageUrls) - 1)));
                INSERT INTO ProductImage (IndexImg, ProductID, Url) VALUES (@Index, @NewProductID, @Url);
                SET @ImageUrls = SUBSTRING(@ImageUrls, CHARINDEX(',', @ImageUrls) + 1, LEN(@ImageUrls));
                SET @Index = @Index + 1;
            END;

            -- Thêm ảnh cuối cùng
            SET @Url = LTRIM(RTRIM(@ImageUrls));
            INSERT INTO ProductImage (IndexImg, ProductID, Url) VALUES (@Index, @NewProductID, @Url);
        END;

        -- Thêm thông tin tồn kho vào bảng Inventory
        INSERT INTO Inventory (ProductID, StockLevel, ReorderLevel)
        VALUES (@NewProductID, @StockLevel, @ReorderLevel);

        COMMIT TRANSACTION;

        -- Trả về ProductID dưới dạng bảng
        SELECT @NewProductID AS ProductID;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        -- Hiển thị lỗi nếu xảy ra
        THROW;
    END CATCH;
END;
GO




create PROCEDURE GetSuggestedProductCategories
@SearchTerm NVARCHAR(100)  -- Tham số đầu vào: chuỗi tìm kiếm
AS
BEGIN
    -- Truy vấn các tên loại sản phẩm có chứa chuỗi tìm kiếm, không phân biệt chữ hoa và chữ thường
    SELECT c.Name AS CategoryName
    FROM Categories c
    WHERE c.Name COLLATE Latin1_General_CI_AS LIKE '%' + @SearchTerm + '%'
    ORDER BY c.Name;  -- Sắp xếp theo tên loại sản phẩm
END;
GO

--drop procedure GetSuggestedProductCategories
--EXEC GetSuggestedProductCategories @SearchTerm = N'Sách';
--drop PROCEDURE DeleteProduct

CREATE PROCEDURE DeleteProduct
    @ProductID INT -- Tham số đầu vào: ID sản phẩm cần xóa
AS
BEGIN
    -- Bắt đầu giao dịch (nếu cần thiết để đảm bảo tính toàn vẹn dữ liệu)
    BEGIN TRANSACTION

    BEGIN TRY
        -- Xóa sản phẩm từ bảng chính (Product)
        DELETE FROM Products WHERE ProductID = @ProductID;

        -- Commit giao dịch (nếu mọi thứ thành công)
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback nếu có lỗi xảy ra
        ROLLBACK TRANSACTION;

        -- Trả về thông báo lỗi
        THROW;
    END CATCH
END;
GO

--exec DeleteProduct @ProductID = 1;
Create PROCEDURE SearchCustomer
    @SearchTerm NVARCHAR(255)  -- Tham số đầu vào là tìm kiếm
AS
BEGIN
    -- Tìm kiếm theo CustomerID (ID khách hàng)
    IF TRY_CAST(@SearchTerm AS INT) IS NOT NULL  -- Kiểm tra nếu @SearchTerm có thể chuyển đổi thành INT
    BEGIN
        SELECT TOP 1000
            [CustomerID],
            [FullName],
            [phone]
        FROM [bookStoreManager_db].[dbo].[Customers]
        WHERE [CustomerID] = @SearchTerm
    END
    -- Tìm kiếm theo số điện thoại
    ELSE IF LEN(@SearchTerm) <= 15  -- Kiểm tra độ dài hợp lý của số điện thoại
    BEGIN
        SELECT TOP 1000
            [CustomerID],
            [FullName],
            [phone]
        FROM [bookStoreManager_db].[dbo].[Customers]
        WHERE [phone] LIKE '%' + @SearchTerm + '%'
    END
    -- Tìm kiếm theo tên khách hàng
    ELSE
    BEGIN
        SELECT TOP 1000
            [CustomerID],
            [FullName],
            [phone]
        FROM [bookStoreManager_db].[dbo].[Customers]
        WHERE [FullName] LIKE N'%' + @SearchTerm + '%'
    END
END

--EXEC SearchCustomer @SearchTerm = N'N'
go

Create PROCEDURE SearchCustomerByPhone
    @Phone VARCHAR(15)  -- Tham số đầu vào là số điện thoại
AS
BEGIN
    SELECT TOP 1000
        [CustomerID],
        [FullName],
        [phone]
    FROM [bookStoreManager_db].[dbo].[Customers]
    WHERE [phone] LIKE N'%' + @Phone + '%'
END

--EXEC SearchCustomerByPhone @Phone = '09'
go
Create PROCEDURE SearchProducts
    @ProductCode INT = NULL,  -- Mã sản phẩm (Có thể bỏ trống)
    @ProductName NVARCHAR(255) = NULL,  -- Tên sản phẩm (Có thể bỏ trống)
    @UnitPrice DECIMAL(18, 2) = NULL,   -- Đơn giá (Có thể bỏ trống)             
    @CategoryName NVARCHAR(255) = NULL  -- Tên thể loại (Có thể bỏ trống)
AS
BEGIN
    SELECT 
        -- Lấy URL hình ảnh đầu tiên (nếu có)
        (SELECT TOP 1 pi.Url 
         FROM ProductImage pi 
         WHERE pi.ProductID = p.ProductID) AS ProductImage,
        p.ProductID, 
        p.Name, 
        p.Price, 
        i.StockLevel, 
        c.Name AS CategoryName
    FROM Products p
    LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
    LEFT JOIN Inventory i ON p.ProductID = i.ProductID
    WHERE
        (p.ProductID = @ProductCode)  -- Kiểm tra Mã sản phẩm
        or (p.Name LIKE N'%' + @ProductName + '%')  -- Kiểm tra tên sản phẩm
        or (p.Price = @UnitPrice)  -- Kiểm tra đơn giá
        or (c.Name LIKE N'%' + @CategoryName + '%');  -- Kiểm tra thể loại
END;
--EXEC SearchProducts @CategoryName = N'';
go
Create PROCEDURE GetOrderDetails
AS
BEGIN
    SELECT 
        o.OrderID,
        o.OrderDate,
        o.CustomerID,
        c.Fullname as CustomerName,
        o.payment_method AS method,
        o.Note,
        o.TotalAmount
    FROM 
        Orders o
    JOIN 
        Customers c ON o.CustomerID = c.CustomerID;
END;

go
--exec GetOrderDetails

CREATE PROCEDURE GetOrderItemsByOrderId
    @OrderID INT
AS
BEGIN
    SELECT 
		p.ProductID,
        p.Name,  -- Lấy tên sản phẩm từ bảng Product
        oi.Quantity,
        oi.CurrentPrice
    FROM OrderItems oi
    INNER JOIN Products p ON oi.ProductID = p.ProductID
    WHERE oi.OrderID = @OrderID;
END

--exec GetOrderItemsByOrderId @orderID =1

go
CREATE PROCEDURE DeleteOrder
    @OrderID INT -- ID của đơn hàng cần xóa
AS
BEGIN
    BEGIN TRY
        -- Kiểm tra xem đơn hàng có tồn tại không
        IF NOT EXISTS (SELECT 1 FROM Orders WHERE OrderID = @OrderID)
        BEGIN
            PRINT 'Đơn hàng không tồn tại.';
            RETURN;
        END

        -- Xóa đơn hàng
        DELETE FROM Orders
        WHERE OrderID = @OrderID;

        PRINT 'Đã xóa đơn hàng thành công.';
    END TRY
    BEGIN CATCH
        -- Bắt lỗi nếu có lỗi xảy ra
        PRINT 'Lỗi khi xóa đơn hàng.';
        PRINT ERROR_MESSAGE();
    END CATCH
END;
GO


--EXEC DeleteOrder @OrderID = 10;

CREATE PROCEDURE GetMonthlyRevenueReport
    @Year INT -- Năm cần báo cáo
AS
BEGIN
    SET NOCOUNT ON;

    -- Tạo báo cáo doanh thu theo tháng
    SELECT 
        MONTH(OrderDate) AS Month, -- Tháng
        COUNT(OrderID) AS OrderCount, -- Số lượng đơn hàng
        SUM(TotalAmount * (1 - Discount / 100)) AS TotalRevenue -- Tổng doanh thu sau chiết khấu
    FROM 
        Orders
    WHERE 
        YEAR(OrderDate) = @Year -- Chỉ lấy các đơn hàng trong năm được chỉ định
    GROUP BY 
        MONTH(OrderDate) -- Nhóm theo tháng
    ORDER BY 
        Month; -- Sắp xếp theo tháng
END;
--exec GetMonthlyRevenueReport @Year =2024
go

Create PROCEDURE GetTodayRevenue
AS
BEGIN
    SET NOCOUNT ON;

    -- Lấy doanh thu và số lượng đơn hàng của ngày hôm nay
    SELECT 
        COUNT(OrderID) AS OrderCount, -- Số lượng đơn hàng hôm nay
        SUM(TotalAmount) AS TotalRevenue -- Tổng doanh thu sau chiết khấu
    FROM 
        Orders
    WHERE 
        CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE); -- Chỉ lấy đơn hàng trong ngày hôm nay
END;

--exec GetTodayRevenue

--drop PROCEDURE GetPasswordByUserInfo
go

CREATE PROCEDURE GetPasswordByUserInfo
    @Identifier NVARCHAR(100) -- Giá trị nhập vào, có thể là username, email hoặc phone
AS
BEGIN
    -- Truy xuất mật khẩu dựa trên username, email hoặc phone
    SELECT password, salt
    FROM Users
    WHERE username = @Identifier 
       OR email = @Identifier 
       OR phone = @Identifier;

    -- Kiểm tra nếu không có kết quả trả về
    IF @@ROWCOUNT = 0
    BEGIN
        PRINT 'Không tìm thấy người dùng với thông tin đã cung cấp.';
    END
END;

--EXEC GetPasswordByUserInfo @Identifier = 'duyanh';
go
Create PROCEDURE GetUserByIdentifier
    @Identifier NVARCHAR(100), -- Có thể là username, phone hoặc email
    @Password VARCHAR(255),     -- Mật khẩu từ người dùng nhập vào
	@Salt VARCHAR(255)
AS
BEGIN
    -- Lấy thông tin người dùng dựa trên identifier
    SELECT 
        user_id AS UserId,
        username AS Username,
        first_name AS FirstName,
        last_name AS LastName,
        email AS Email,
        old AS Old,
        sex AS Sex,
        Role AS Role,
        phone AS Phone,
        Salary AS Salary,
        address_line AS AddressLine,
        city AS City,
        province AS Province
    FROM Users
    WHERE 
        (username = @Identifier OR phone = @Identifier OR email = @Identifier) and password = @Password and salt = @Salt ;
END

GO

--exec GetUserByIdentifier     @Identifier = 'duyanh123', @Password ='qu4rmP1/5v2IL0KNL1Q8sVfSR8R9GhiaAuaIkR+6t9E=', @Salt = 'i9Pf9g0gnonms5OT0gXmXQ=='

CREATE PROCEDURE GetRestockOrderDetails
AS
BEGIN
    SELECT 
        ro.RestockOrderID, 
        ro.RestockDate, 
        s.Name AS SupplierName, 
        ro.TotalAmount, 
        ro.Status
    FROM 
        RestockOrders ro
    LEFT JOIN 
        Suppliers s ON ro.SupplierID = s.SupplierID;
END;


--EXEC GetRestockOrderDetails;

go

CREATE PROCEDURE GetTop10BestSellingProducts
AS
BEGIN
    -- Truy vấn lấy top 10 sản phẩm bán chạy nhất trong tuần
    SELECT TOP 10 
        p.Name AS ProductName,
        SUM(oi.Quantity) AS TotalQuantitySold
    FROM OrderItems oi
    INNER JOIN Products p ON oi.ProductID = p.ProductID
    INNER JOIN Orders o ON oi.OrderID = o.OrderID
    WHERE 
        o.OrderDate >= DATEADD(DAY, -7, GETDATE()) -- Chỉ lấy đơn hàng trong 7 ngày gần đây
        AND o.OrderDate <= GETDATE()
    GROUP BY p.Name
    ORDER BY TotalQuantitySold DESC;
END;

--EXEC GetTop10BestSellingProducts;
