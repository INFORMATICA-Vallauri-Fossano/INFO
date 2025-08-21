--SELECT L.* FROM PRESTITI P right JOIN LETTORI L ON P.idPrestito=L.idLettore WHERE DATEDIFF(DAY,P.dataInizio,GETDATE())>30
--SELECT P.dataInizio, DATEDIFF(DAY, cast(P.dataInizio as date), GETDATE()) AS DaysAgo FROM PRESTITI P
--SELECT l.idLettore,l.cognome,l.nome,l.email,l.telefono FROM PRESTITI P left JOIN LETTORI L ON P._idLettore=L.idLettore 
--WHERE DATEDIFF(DAY,P.dataInizio,GETDATE())>30
--group by l.idLettore,l.cognome,l.nome,l.email,l.telefono
--SELECT AVG(DATEDIFF(DAY,DATAINIZIO,DATAFINE)) FROM PRESTITI
--SELECT P.DATAINIZIO,L.TITOLO,p.datafine FROM PRESTITI P LEFT JOIN LIBRI L ON P._CODICEISBN=L.CODICEISBN where p.dataFine is null
SELECT YEAR(DATAINIZIO) AS 'ANNO'
,sum(iif(month(datainizio)=1,1,0)) as 'Gennaio'
,sum(iif(month(datainizio)=2,1,0)) as 'Febbraio'
,sum(iif(month(datainizio)=3,1,0)) as 'Marzo'
,sum(iif(month(datainizio)=4,1,0)) as 'Aprile'
,sum(iif(month(datainizio)=5,1,0)) as 'Maggio'
,sum(iif(month(datainizio)=6,1,0)) as 'Giugno'
,sum(iif(month(datainizio)=7,1,0)) as 'Luglio'
,sum(iif(month(datainizio)=8,1,0)) as 'Agosto'
,sum(iif(month(datainizio)=9,1,0)) as 'Settembre'
,sum(iif(month(datainizio)=10,1,0)) as 'Ottobre'
,sum(iif(month(datainizio)=11,1,0)) as 'Novembre'
,sum(iif(month(datainizio)=12,1,0)) as 'Dicembre'
,count(*) as 'Totale'FROM PRESTITI
GROUP BY YEAR(DATAINIZIO) 