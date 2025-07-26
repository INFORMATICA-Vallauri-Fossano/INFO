insert into GENERI(genere)
values
('Personal Development'),
('Psychological'),
('Testimonianza'),
('Saggistica'),
('Romantico')


;

insert into LETTORI(cognome,nome,telefono,email)
values
('Anrango Ramos','Gionsi','3403887295','r34d3r20@gmail.com'),
('sur1','nam1','1111111111','client1@gmail.com'),
('sur2','nam2','2222222222','client2@gmail.com'),
('sur3','nam3','3333333333','client3@gmail.com')

;

insert into AUTORI(cognome,nome)
values
('Clear','James'),
('Conrad','Joseph'),
('Levi','Primo'),
('Freud','Sigmund'),
('Bronte','Emily')
;

insert into LIBRI(codiceISBN,titolo,numeroPagine,dataPubblicazione,collocazione,copertina,casaEditrice,disponibile,_idGenere)
values
('9791221208870',
'Atomic Habits. An Easy and Proven Way to Build Good Habits and Break Bad Ones',
332,'2018-10-16','A21','/copertine/9791221208870.png','DeAgostini',0,1),

('9788871007618',
'Heart of Darkness',111,'1995-01-01','A11','/copertine/9788871007618.png','LaSpigaLanguages',1,2),

('9788806219338',
'La Tregua',225,'2014-01-01','A31','/copertine/9788806219338.png','Einaudi',0,3),

('9788809975354',
'L''interpretazione dei sogni',668,'2023-01-01','A11','/copertine/9788809975354.png','Giunti',0,4),

('9788877547996',
'Wuthering Heights',128,'2002-01-01','A41','/copertine/9788877547996.png','NewtonCompton',1,5)
;


insert into SCRIVONO(_codiceISBN,_idAutore)
values
('9791221208870',1),
('9788871007618',2),
('9788806219338',3),
('9788809975354',4),
('9788877547996',5)

insert into PRESTITI(_idLettore,_codiceISBN,dataInizio,dataFine)
values
(1,'9791221208870','2025-06-08',null),
(1,'9788806219338','2024-06-08',null),
(1,'9788809975354','2024-06-08',null),
(2,'9788871007618','2023-06-08','2025-06-08'),
(3,'9788877547996','2023-06-08','2025-06-08')

;