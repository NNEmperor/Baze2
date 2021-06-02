CREATE FUNCTION F_GET_Radnik_Plt
(
@P_Mbr INT 
) RETURNS DECIMAL
AS 
BEGIN 
DECLARE
@return_value AS DECIMAL;
SELECT @return_value = Plt FROM radnik
WHERE MBR= @P_Mbr; 
RETURN @return_value;
END;