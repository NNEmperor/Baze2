alter FUNCTION F_GET_Igrac_Visina
(
@P_ID INT 
) RETURNS DECIMAL
AS 
BEGIN 
DECLARE
@return_value AS DECIMAL;
SELECT @return_value = VIS_IG FROM Igraci
WHERE ID_IG= @P_ID; 
RETURN @return_value;
END;

declare @res VARCHAR(20)
exec @res = F_GET_PevackiKoncert_Pevanje 1
select @res

Create FUNCTION F_GET_Koncert_TIP
(
@P_ID INT 
) RETURNS VARCHAR(20)
AS 
BEGIN 
DECLARE
@return_value AS VARCHAR(20);
SELECT @return_value = TIP_KC FROM Koncerti
WHERE ID_KC = @P_ID; 
RETURN @return_value;
END;

Create FUNCTION F_GET_IgrackiKoncert_Koreografija
(
@P_ID INT 
) RETURNS VARCHAR(20)
AS 
BEGIN 
DECLARE
@return_value AS VARCHAR(20);
SELECT @return_value = IG_KOR FROM Koncerti_IgrackiKoncert
WHERE ID_KC = @P_ID; 
RETURN @return_value;
END;

Create FUNCTION F_GET_PevackiKoncert_Pevanje
(
@P_ID INT 
) RETURNS VARCHAR(20)
AS 
BEGIN 
DECLARE
@return_value AS VARCHAR(20);
SELECT @return_value = PEV_TIP FROM Koncerti_PevackiKoncert
WHERE ID_KC = @P_ID; 
RETURN @return_value;
END;

Create FUNCTION F_GET_Koreograf_Prezime
(
@P_ID INT 
) RETURNS VARCHAR(20)
AS 
BEGIN 
DECLARE
@return_value AS VARCHAR(20);
SELECT @return_value = PR_KOR FROM Koreografi
WHERE ID_KOR = @P_ID; 
RETURN @return_value;
END;

Create FUNCTION F_GET_Muzika_Tip
(
@P_ID INT 
) RETURNS VARCHAR(20)
AS 
BEGIN 
DECLARE
@return_value AS VARCHAR(20);
SELECT @return_value = TIP_MUZ FROM Muzike
WHERE ID_MUZ = @P_ID; 
RETURN @return_value;
END;

Create FUNCTION F_GET_Nosnje_Naziv
(
@P_ID INT 
) RETURNS VARCHAR(20)
AS 
BEGIN 
DECLARE
@return_value AS VARCHAR(20);
SELECT @return_value = IME_NOS FROM Nosnje
WHERE ID_NOS = @P_ID; 
RETURN @return_value;
END;

Create FUNCTION F_GET_Proba_Tip
(
@P_ID INT 
) RETURNS VARCHAR(20)
AS 
BEGIN 
DECLARE
@return_value AS VARCHAR(20);
SELECT @return_value = TIP_PROB FROM Probe
WHERE ID_PROB = @P_ID; 
RETURN @return_value;
END;

Create FUNCTION F_GET_Sastav_Ime
(
@P_ID INT 
) RETURNS VARCHAR(20)
AS 
BEGIN 
DECLARE
@return_value AS VARCHAR(20);
SELECT @return_value = IME_SS FROM Sastavi
WHERE ID_SS = @P_ID; 
RETURN @return_value;
END;











