IF NOT EXISTS (
    SELECT name
    FROM sys.databases
    WHERE name = N'QPharma1'
)
BEGIN
    CREATE DATABASE QPharma1;
END


use QPharma1



create table users(
username varchar(30) primary key,
hash_pw varchar(100)
)


create table staffs(
staff_id varchar(30) primary key,
staff_name nvarchar(30),
staff_sex bit,
staff_year_of_birth date,
staff_is_manager bit,
staff_is_seller bit,
staff_created datetime,
staff_updated datetime,
staff_deleted datetime,
username varchar(30) foreign key references users(username)
)
create table suppliers(
supplier_id varchar(30) primary key,
supplier_name nvarchar(50),
supplier_note nvarchar(200),
supplier_phone varchar(15),
supplier_email varchar(30),
supplier_status bit,
supplier_created datetime,
supplier_updated datetime,
supplier_deleted datetime
)
create table categories(
category_id int IDENTITY(1,1) primary key,
category_name nvarchar(30),
category_note nvarchar(30),
category_status bit,
category_created datetime,
category_updated datetime,
category_deleted datetime,
unique(category_name)
)
create table customers (
customer_id int IDENTITY(1,1) primary key,
customer_name nvarchar(30),
customer_phone varchar(15),
customer_address nvarchar(100),
customer_note nvarchar(100),
customer_status bit,
customer_created datetime,
customer_updated datetime,
customer_deleted datetime
)
create table medicine_locations(
medicine_location_id int IDENTITY(1,1) primary key,
medicine_location_name nvarchar(30),
medicine_location_note nvarchar(30),
medicine_location_status bit,
medicine_location_created datetime,
medicine_location_updated datetime,
medicine_location_deleted datetime,
unique(medicine_location_name)
)
create table medicines(
medicine_id varchar(30) primary key,
medicine_name nvarchar(100),
medicine_mfg date,
medicine_expire_date date,
medicine_unit nvarchar(30),
medicine_price_in int,
medicine_price_out int,
medicine_quantity int,
medicine_type bit,
medicine_image nvarchar(200),
medicine_description ntext,
medicine_created datetime,
medicine_updated datetime,
medicine_deleted datetime,
supplier_id varchar(30) foreign key references suppliers(supplier_id),
category_id int foreign key references categories(category_id),
medicine_location_id int foreign key references medicine_locations(medicine_location_id),
)
create table bills(
bill_id int IDENTITY(1,1) primary key,
bill_total int,
bill_customer_paid int,
bill_status bit,
bill_note ntext,
customer_id int foreign key references customers(customer_id),
staff_id varchar(30) foreign key references staffs(staff_id),
bill_created datetime,
bill_deleted datetime
)
create table bill_details(
bill_id int foreign key references bills(bill_id),
medicine_id varchar(30) foreign key references medicines(medicine_id),
bill_detail_quantity int,
bill_detail_price int,
primary key (bill_id, medicine_id)
)
create table suppliers_history(
supplier_id varchar(30) foreign key references suppliers(supplier_id),
medicine_id varchar(30) foreign key references medicines(medicine_id),
supplier_history_price int,
supplier_history_quantity int,
supplier_history_created datetime,
supplier_history_deleted datetime,
primary key (supplier_id, medicine_id, supplier_history_created)
)
create table login_log(
login_log_id varchar(100) primary key,
username varchar(30) foreign key references users(username),
login_time datetime,
logout_time datetime
)



INSERT INTO users
(username, hash_pw)
VALUES('admin', '$2a$12$o32w9utWr65ZcNmk3bDQtOuzvJ4uai4KHpqMVJVhPgXQILJ63xjZO');

INSERT INTO staffs
(staff_id, staff_name, staff_sex, staff_year_of_birth, staff_is_manager, staff_is_seller, staff_created, staff_updated, staff_deleted, username)
VALUES('nv1', 'Nguyen Van A', 1, getdate(), 1, 0, getdate(), '', '', 'admin');

