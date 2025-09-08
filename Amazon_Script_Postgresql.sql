CREATE TABLE "User" (
  "UserId" SERIAL PRIMARY KEY,
  "FirstName" VARCHAR(100) NOT NULL,
  "LastName" VARCHAR(100) NOT NULL,
  "Username" VARCHAR(100) NOT NULL UNIQUE,
  "Password" TEXT NOT NULL,
  "Email" VARCHAR(100) NOT NULL UNIQUE,
  "PhoneNo" VARCHAR(10) UNIQUE,
  "Role" VARCHAR(20) NOT NULL,
  "IsActive" BOOLEAN DEFAULT TRUE,
  "CreatedBy" INT NOT NULL DEFAULT 1,
  "CreatedOn" TIMESTAMP with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "UpdatedBy" INT,
  "UpdatedOn" TIMESTAMP with time zone
);

CREATE TABLE "Tag" (
  "TagId" SERIAL PRIMARY KEY,
  "Tag" TEXT,
  "IsActive" BOOLEAN DEFAULT TRUE,
  "CreatedBy" INT NOT NULL DEFAULT 1,
  "CreatedOn" TIMESTAMP with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "UpdatedBy" INT,
  "UpdatedOn" TIMESTAMP with time zone
);

CREATE TABLE "Product" (
  "ProductId" SERIAL PRIMARY KEY,
  "UserId" INT NOT NULL REFERENCES "User"("UserId") ON DELETE CASCADE,
  "Title" VARCHAR(100) NOT NULL,
  "Brand" VARCHAR(100),
  "Category" VARCHAR(100) NOT NULL,
  "Price" DECIMAL(12,2) NOT NULL,
  "Rating" DECIMAL(3,1),
  "IsActive" BOOLEAN DEFAULT TRUE,
  "CreatedBy" INT NOT NULL DEFAULT 1,
  "CreatedOn" TIMESTAMP with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "UpdatedBy" INT,
  "UpdatedOn" TIMESTAMP with time zone,
  UNIQUE ("Title", "Category")
);


CREATE TABLE "ProductDetail" (
  "ProductDetailId" SERIAL PRIMARY KEY,
  "ProductId" INT NOT NULL UNIQUE REFERENCES "Product"("ProductId") ON DELETE CASCADE,
  "Description" TEXT NOT NULL,
  "Stock" INT NOT NULL,
  "sku" VARCHAR(100) NOT NULL,
  "Weight" DECIMAL(6,2) NOT NULL,
  "Discount" DECIMAL(5,2),
  "Warranty" VARCHAR(100) NOT NULL,
  "Shipping" VARCHAR(100),
  "ReturnPolicy" VARCHAR(100) NOT NULL,
  "IsActive" BOOLEAN DEFAULT TRUE,
  "CreatedBy" INT NOT NULL DEFAULT 1,
  "CreatedOn" TIMESTAMP with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "UpdatedBy" INT,
  "UpdatedOn" TIMESTAMP with time zone
);


CREATE TABLE "ImageType" (
  "ImageTypeId" SERIAL PRIMARY KEY,
  "Name" VARCHAR(50) NOT NULL,
  "Description" VARCHAR(150),
  "IsActive" BOOLEAN DEFAULT TRUE,
  "CreatedBy" INT NOT NULL DEFAULT 1,
  "CreatedOn" TIMESTAMP with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "UpdatedBy" INT,
  "UpdatedOn" TIMESTAMP with time zone
);

CREATE TABLE "Image" (
  "ImageId" SERIAL PRIMARY KEY,
  "ProductId" INT NOT NULL REFERENCES "Product"("ProductId") ON DELETE CASCADE,
  "ImageTypeId" INT NOT NULL DEFAULT 101 REFERENCES "ImageType"("ImageTypeId") ON DELETE CASCADE,
  "Image" BYTEA,
  "ImageName" VARCHAR(100),
  "ImageType" VARCHAR(100),
  "IsActive" BOOLEAN DEFAULT TRUE,
  "CreatedBy" INT NOT NULL DEFAULT 1,
  "CreatedOn" TIMESTAMP with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "UpdatedBy" INT,
  "UpdatedOn" TIMESTAMP with time zone
);

CREATE TABLE "Review" (
  "ReviewId" SERIAL PRIMARY KEY,
  "ProductId" INT NOT NULL REFERENCES "Product"("ProductId") ON DELETE CASCADE,
  "ReviewerName" VARCHAR(100) NOT NULL,
  "ReviewerEmail" VARCHAR(100) NOT NULL,
  "Comment" TEXT,
  "Rating" DECIMAL(3,1),
  "IsActive" BOOLEAN DEFAULT TRUE,
  "CreatedBy" INT NOT NULL DEFAULT 1,
  "CreatedOn" TIMESTAMP with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "UpdatedBy" INT,
  "UpdatedOn" TIMESTAMP with time zone
);

CREATE TABLE "Order" (
  "OrderId" SERIAL PRIMARY KEY,
  "UserId" INT NOT NULL REFERENCES "User"("UserId") ON DELETE CASCADE,
  "ProductId" INT NOT NULL REFERENCES "Product"("ProductId") ON DELETE CASCADE,
  "IsActive" BOOLEAN DEFAULT TRUE,
  "CreatedBy" INT NOT NULL DEFAULT 1,
  "CreatedOn" TIMESTAMP with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "UpdatedBy" INT,
  "UpdatedOn" TIMESTAMP with time zone
);

CREATE TABLE "Cart" (
  "CartId" SERIAL PRIMARY KEY,
  "UserId" INT NOT NULL UNIQUE REFERENCES "User"("UserId") ON DELETE CASCADE,
  "IsActive" BOOLEAN DEFAULT TRUE,
  "CreatedBy" INT NOT NULL DEFAULT 1,
  "CreatedOn" TIMESTAMP with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "UpdatedBy" INT,
  "UpdatedOn" TIMESTAMP with time zone
);

CREATE TABLE "UserCart" (
  "UserCartId" SERIAL PRIMARY KEY,
  "CartId" INT NOT NULL REFERENCES "Cart"("CartId") ON DELETE CASCADE,
  "ProductId" INT NOT NULL REFERENCES "Product"("ProductId") ON DELETE CASCADE,
  "IsActive" BOOLEAN DEFAULT TRUE,
  "CreatedBy" INT NOT NULL DEFAULT 1,
  "CreatedOn" TIMESTAMP with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "UpdatedBy" INT,
  "UpdatedOn" TIMESTAMP with time zone
);

CREATE TABLE "ProductTag"(
  "ProductTagId" SERIAL PRIMARY KEY,
  "ProductId" INT NOT NULL REFERENCES "Product"("ProductId") ON DELETE CASCADE,
  "TagId" INT NOT NULL REFERENCES "Tag"("TagId") ON DELETE CASCADE,
  "IsActive" BOOLEAN DEFAULT TRUE
);

CREATE TABLE "ConfirmCart"(
  "ConfirmCartId" SERIAL PRIMARY KEY,
  "CartId" INT NOT NULL REFERENCES "Cart"("CartId") ON DELETE CASCADE,
  "ProductId" INT NOT NULL REFERENCES "Product"("ProductId") ON DELETE CASCADE,
  "IsActive" BOOLEAN DEFAULT TRUE,
  "CreatedBy" INT NOT NULL DEFAULT 1,
  "CreatedOn" TIMESTAMP with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "UpdatedBy" INT,
  "UpdatedOn" TIMESTAMP with time zone
);


