create trigger Brisi_Igrac
on Igraci
instead of delete
as
begin

delete from Nastupaju
where IgracID_IG in (select ID_IG from deleted)

delete from Pripadanje
where IgracID_IG in (select ID_IG from deleted)

delete from Nosnje
where NastupaIgracID_IG in (select ID_IG from deleted)

end

create trigger Brisi_Sastav
on Sastavi
instead of delete
as
begin

delete from Vodjenje
where SastavID_SS in (select ID_SS from deleted)

delete from Pripadanje
where SastavID_SS in (select ID_SS from deleted)

end

create trigger Brisi_Koncert
on Koncerti
instead of delete
as
begin

delete from Koncerti_IgrackiKoncert
where ID_KC in (select ID_KC from deleted)

delete from Koncerti_PevackiKoncert
where ID_KC in (select ID_KC from deleted)

delete from Nastupaju
where KoncertID_KC in (select ID_KC from deleted)

delete from Nosnje
where NastupaKoncertID_KC in (select ID_KC from deleted)

end


create trigger Brisi_Muzika
on Muzike
instead of delete
as
begin

delete from Koncerti_IgrackiKoncert
where MuzikaID_MUZ in (select ID_MUZ from deleted)

end


create trigger Brisi_Koreografa
on Koreografi
instead of delete
as
begin

delete from Vodjenje
where KoreografID_KOR in (select ID_KOR from deleted)

end