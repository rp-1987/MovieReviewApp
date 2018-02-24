/*
usp_AddCritic @CriticName = 'MID-DAY', @Publication = 'MID-DAY'
*/
CREATE PROCEDURE usp_AddCritic
@CriticName VARCHAR(100),
@Publication VARCHAR(100),
@IsTopCritic BIT = 0
AS 
BEGIN

IF NOT EXISTS(SELECT 1 FROM Critics WHERE CriticName = @CriticName)
BEGIN
	INSERT INTO Critics (CriticName, Publication, IsTopCritic)
	VALUES(@CriticName, @Publication, @IsTopCritic)
END

ELSE
 PRINT 'Already There'


END