CREATE PROCEDURE P_INS_IGRAC
(
@IME_IG VARCHAR(20), 
@PR_IG VARCHAR(20), 
@VIS_IG DECIMAL, 
@POL_IG VARCHAR(20) 
) 
AS 
BEGIN TRY 
INSERT INTO Igraci(IME_IG, PR_IG, VIS_IG, POL_IG)
VALUES (@IME_IG, @PR_IG, @VIS_IG, @POL_IG);
END TRY 
BEGIN CATCH 
SELECT 
ERROR_NUMBER() AS ErrorNumber
,ERROR_MESSAGE() AS ErrorMessage; 
END CATCHexec P_INS_IGRAC 'Nikola', 'Nikolic', 193, 'Musko'CREATE PROCEDURE P_INS_KOREOGRAF
(
@IME_KOR VARCHAR(20), 
@PR_KOR VARCHAR(20)
) 
AS 
BEGIN TRY 
INSERT INTO Koreografi(IME_KOR, PR_KOR)
VALUES (@IME_KOR, @PR_KOR);
END TRY 
BEGIN CATCH 
SELECT 
ERROR_NUMBER() AS ErrorNumber
,ERROR_MESSAGE() AS ErrorMessage; 
END CATCH

CREATE PROCEDURE P_INS_KONCERT
(
@TIP_KC VARCHAR(20), 
@VR_KC DATETIME
) 
AS 
BEGIN TRY 
INSERT INTO Koncerti(TIP_KC, VR_KC)
VALUES (@TIP_KC, @VR_KC);
END TRY 
BEGIN CATCH 
SELECT 
ERROR_NUMBER() AS ErrorNumber
,ERROR_MESSAGE() AS ErrorMessage; 
END CATCH

CREATE PROCEDURE P_INS_MUZIKA
(
@TIP_MUZ VARCHAR(20)
) 
AS 
BEGIN TRY 
INSERT INTO Muzike(TIP_MUZ)
VALUES (@TIP_MUZ);
END TRY 
BEGIN CATCH 
SELECT 
ERROR_NUMBER() AS ErrorNumber
,ERROR_MESSAGE() AS ErrorMessage; 
END CATCH

CREATE PROCEDURE P_INS_IGRACKIKONCERT
(
@ID_MUZIKE INT,
@IG_KOR VARCHAR(20)
) 
AS 
BEGIN TRY 
INSERT INTO Koncerti_IgrackiKoncert(MuzikaID_MUZ, IG_KOR)
VALUES (@ID_MUZIKE, @IG_KOR);
END TRY 
BEGIN CATCH 
SELECT 
ERROR_NUMBER() AS ErrorNumber
,ERROR_MESSAGE() AS ErrorMessage; 
END CATCH

CREATE PROCEDURE P_INS_NASTUP
(
@ID_IG INT,
@ID_KC INT
) 
AS 
BEGIN TRY 
INSERT INTO Nastupaju(IgracID_IG, KoncertID_KC)
VALUES (@ID_IG, @ID_KC);
END TRY 
BEGIN CATCH 
SELECT 
ERROR_NUMBER() AS ErrorNumber
,ERROR_MESSAGE() AS ErrorMessage; 
END CATCH

CREATE PROCEDURE P_INS_NOSNJU
(
@IME_NOS VARCHAR(20),
@ID_IG INT,
@ID_KC INT
) 
AS 
BEGIN TRY 
INSERT INTO Nosnje(IME_NOS, NastupaIgracID_IG, NastupaIgrac_ID_KC)
VALUES (@IME_NOS, @ID_IG, @ID_KC);
END TRY 
BEGIN CATCH 
SELECT 
ERROR_NUMBER() AS ErrorNumber
,ERROR_MESSAGE() AS ErrorMessage; 
END CATCH

CREATE PROCEDURE P_INS_PEVACKIKONCERT
(
@PEV_TIP VARCHAR(20)
) 
AS 
BEGIN TRY 
INSERT INTO Koncerti_PevackiKoncert(PEV_TIP)
VALUES (@PEV_TIP);
END TRY 
BEGIN CATCH 
SELECT 
ERROR_NUMBER() AS ErrorNumber
,ERROR_MESSAGE() AS ErrorMessage; 
END CATCH

CREATE PROCEDURE P_INS_PRIPADA
(
@ID_IG INT,
@ID_SS INT
) 
AS 
BEGIN TRY 
INSERT INTO Pripadanje(IgracID_IG, SastavID_SS)
VALUES (@ID_IG, @ID_SS);
END TRY 
BEGIN CATCH 
SELECT 
ERROR_NUMBER() AS ErrorNumber
,ERROR_MESSAGE() AS ErrorMessage; 
END CATCH

CREATE PROCEDURE P_INS_VODI
(
@ID_KOR INT,
@ID_SS INT
) 
AS 
BEGIN TRY 
INSERT INTO Vodjenje(KoreografID_KOR, SastavID_SS)
VALUES (@ID_KOR, @ID_SS);
END TRY 
BEGIN CATCH 
SELECT 
ERROR_NUMBER() AS ErrorNumber
,ERROR_MESSAGE() AS ErrorMessage; 
END CATCH

CREATE PROCEDURE P_INS_SASTAV
(
@IME_SS VARCHAR(20)
) 
AS 
BEGIN TRY 
INSERT INTO Sastavi(IME_SS)
VALUES (@IME_SS);
END TRY 
BEGIN CATCH 
SELECT 
ERROR_NUMBER() AS ErrorNumber
,ERROR_MESSAGE() AS ErrorMessage; 
END CATCH

CREATE PROCEDURE P_INS_PROBA
(
@SastavID_SS INT,
@TIP_PROB VARCHAR(20),
@VR_PROB DATETIME
) 
AS 
BEGIN TRY 
INSERT INTO Probe(SastavID_SS, TIP_PROB, VR_PROB)
VALUES (@SastavID_SS, @TIP_PROB, @VR_PROB);
END TRY 
BEGIN CATCH 
SELECT 
ERROR_NUMBER() AS ErrorNumber
,ERROR_MESSAGE() AS ErrorMessage; 
END CATCH