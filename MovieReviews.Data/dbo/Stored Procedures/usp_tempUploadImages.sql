
CREATE PROCEDURE usp_tempUploadImages
@MovieName VARCHAR(MAX),
@Path VARCHAR(MAX)
AS
BEGIN

DECLARE @MovieId INT

SELECT TOP 1 @MovieId = ID FROM Movies WHERE MovieName LIKE '%' + @MovieName + '%'

INSERT INTO MoviePosters(MovieId, PosterImage) 
SELECT @MovieId, BulkColumn 
FROM Openrowset( Bulk 'E:\MyApps\MovieReview\V2\Mocks\img\Baar-Baar-Dekho-First-Look-Poster-2.jpg', Single_Blob) as image
END