CREATE TABLE Investigaciones (
    Id INT IDENTITY PRIMARY KEY,
    Prompt NVARCHAR(MAX),
    Resultado NVARCHAR(MAX),
    FechaHora DATETIME DEFAULT GETDATE()
)