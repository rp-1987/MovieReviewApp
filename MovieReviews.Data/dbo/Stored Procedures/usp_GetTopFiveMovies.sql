CREATE PROCEDURE usp_GetTopFiveMovies
AS
BEGIN

DECLARE @tblTopFiveMovies TABLE
(
	MovieId INT,
	MovieName VARCHAR(100),
	Director VARCHAR(200),
	Rating NUMERIC(10,2)
)


INSERT INTO @tblTopFiveMovies
(
	MovieId,
	MovieName,
	Director
)
SELECT ID,
       MovieName,
	   Director 
FROM Movies
WHERE ID IN (1,2,3,4,5)

UPDATE T
SET T.Rating = Y.Rating
FROM @tblTopFiveMovies T 
     INNER JOIN 
(
SELECT X.MovieId, (SUM(X.Num)/ SUM(X.Den)) * 100 AS [Rating]  FROM
(
SELECT  MovieID,
        CASE IsGood WHEN 0 THEN 0.00 ELSE 1 END AS [Num],
        1.00  as [Den]
FROM MovieReviews WHERE MovieID IN (1,2,3,4,5)
)X
GROUP BY X.MovieId
)Y
ON Y.MovieId = T.MovieId

SELECT * FROM @tblTopFiveMovies

END