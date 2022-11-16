create database bd_farmacia
GO
USE bd_farmacia
GO

create table cliente(
cod_clt int identity (1,1)primary key,
nombre varchar(15) not null,
paterno varchar(20) not null,
materno varchar(20),
direccion varchar(100),
telefono varchar(30),
correo varchar(60)
)
GO

create table empleado(
ci int identity (1,1)primary key,
nombre varchar(30) not null,
paterno varchar(30) not null,
materno varchar(30),
direccion varchar(100)not null,
telefono int
)
GO

create table categoria(
cod_cat int identity (1,1)primary key,
nombre varchar(30) not null
)
GO
create table laboratorio(
cod_lab int identity (1,1) primary key,
nombre varchar(20) not null,
direccion varchar(100) not null,
telefono char (12)not null,
email varchar(60),
web varchar(60),
)
GO
create table ajuste(
cod_ajt int identity (1,1)primary key,
fecha smalldatetime not null,
observacion varchar(200) not null
)
GO
create table venta(
nro_venta int identity (1,1) primary key,
fecha smalldatetime,
cod_clt int not null,
cod_emp int not null,
foreign key (cod_clt) references cliente (cod_clt),
foreign key (cod_emp) references empleado(ci)
)
GO
create table medicamento(
cod_med int identity (1,1)primary key,
nombre varchar(30) not null,
precio money not null,
stock int not null,
cod_cat int 
foreign key (cod_cat) references categoria(cod_cat)
)
GO
create table detalleVenta(
nro_venta int not null,
cod_med int not null,
cantidad int not null,
precio money not null,
primary key(nro_venta,cod_med),
foreign key (nro_venta) references venta(nro_venta),
foreign key (cod_med) references medicamento(cod_med)
)
GO
create table proveedor(
cod_provee int identity (1,1)primary key,
nombre varchar(60) not null,
nit varchar(30)not null,
direccion varchar(100),
telefono int not null,
cod_lab int not null,
foreign key(cod_lab) references laboratorio(cod_lab)
)
GO
create table compra(
cod_compra int identity (1,1)primary key,
fecha smalldatetime not null,
cod_provee int not null,
cod_emp int not null,
foreign key (cod_provee) references proveedor(cod_provee),
foreign key (cod_emp) references empleado(ci)
)
GO
create table detalleCompra(
cod_compra int not null,
cod_med int not null,
cantidad int not null,
costo money not null,
primary key(cod_compra,cod_med),
foreign key(cod_compra) references compra(cod_compra),
foreign key(cod_med) references medicamento (cod_med)
)
GO
create table detalleAjuste(
cod_ajt int not null, 
cod_med int not null,
cantidad int not null,
primary key(cod_ajt,cod_med),
foreign key(cod_ajt) references ajuste(cod_ajt),
foreign key(cod_med) references medicamento(cod_med)
)
GO
create table ubicacion(
cod_med int not null,
cod_lab int not null,
primary key(cod_med,cod_lab),
foreign key(cod_med) references medicamento(cod_med),
foreign key(cod_lab) references laboratorio (cod_lab)
)
GO
