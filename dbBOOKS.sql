--PHYSUCAL SCHEME
create table GENERI(
idGenere int primary key identity(1,1),
genere varchar(50) not null
);

create table LETTORI(
idLettore int primary key identity(1,1),
cognome varchar(50) not null,
nome varchar(50) not null,
telefono varchar(25) not null,
email varchar(50) not null
)
create table AUTORI(
idAutore int primary key identity(1,1),
cognome varchar(50) not null,
nome varchar(50) not null
)

create table LIBRI(
codiceISBN varchar(17) primary key,
titolo varchar(100) not null,
numeroPagine int not null,
dataPubblicazione date not null,
collocazione varchar(5) not null,
copertina varchar(100) not null,
casaEditrice varchar(50) not null,
disponibile bit not null,
_idGenere int not null,
foreign key (_idGenere) references GENERI(idGenere)
)

create table SCRIVONO(
idScrivono int primary key identity(1,1),
_idAutore int not null,
_codiceISBN varchar(17) not null,
foreign key (_idAutore) references AUTORI(idAutore),
foreign key (_codiceISBN) references LIBRI(codiceISBN)
)

create table PRESTITI(
idPrestito int primary key identity(1,1),
_idLettore int not null,
_codiceISBN varchar(17) not null,
dataInizio date not null,
dataFine date,
foreign key (_idLettore) references LETTORI(idLettore),
foreign key (_codiceISBN) references LIBRI(codiceISBN)
)