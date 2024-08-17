DROP TABLE IF EXISTS categorias;

CREATE TABLE categorias (
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100) NOT NULL
);

INSERT INTO categorias (nome) VALUES 
('Beleza'),
('Self Care'),
('Frutas'),
('Verdeuras'),
('Limpeza'),
('Churrasco'),
('Medicamentos');