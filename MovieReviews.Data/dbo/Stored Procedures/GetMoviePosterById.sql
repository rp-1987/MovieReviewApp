CREATE PROCEDURE GetMoviePosterById
@MovieId INT
AS
BEGIN
   SELECT TOP 1 MovieId, PosterImage, MimeType
   FROM MoviePosters
   WHERE MovieId = @MovieId
END