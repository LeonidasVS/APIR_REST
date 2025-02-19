create database APIREST

use APIREST

CREATE TABLE Productos(
	IdProducto INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	Precio DECIMAL(6, 2) NOT NULL,
	Stock INT NOT NULL
);

select * from Productos;

INSERT INTO Productos (Nombre, Precio, Stock) VALUES
('Laptop', 12, 100),
('Smartphone', 359, 25),
('Tablet', 680, 15),
('Auriculares', 45, 50),
('Reloj inteligente', 245, 30);
