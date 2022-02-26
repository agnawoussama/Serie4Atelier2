create database serie4Atelier2
use serie4Atelier2

create table Membres(
loginn varchar(30) PRIMARY KEY,
motPass varchar(30),
nom varchar(40),
email varchar(50),
dateNaissance date)
drop table Membres
INSERT INTO Membres VALUES 
('Admin', 'admin', 'Admin', 'Admin@gmail.com', '1995-02-01'),
('Amin', 'amin123', 'Amin', 'amin@gmail.com', '1995-02-01'),
('Oussama', 'oussama123', 'Oussama', 'oussama@gmail.com', '1997-11-01'),
('Nizar', 'nizar123', 'Nizar', 'nizar@gmail.com', '1996-06-03'),
('Alaoui', 'alaoui123', 'Alaoui', 'alaoui@gmail.com', '1991-08-07'),
('Moncef', 'moncef123', 'Moncef', 'admin@gmail.com', '1995-10-08')

select * from Membres;