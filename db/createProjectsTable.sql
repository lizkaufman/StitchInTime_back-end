CREATE TABLE IF NOT EXISTS Projects (
    id SERIAL PRIMARY KEY,
    projectName TEXT NOT NULL,
    projectType TEXT NOT NULL,
    currentRowsDone INT,
    currentStitchesDone INT,
    rowTarget INT,
    stitchTarget INT,
    projectImageUrl TEXT,
    patternUrl TEXT,
    startDate DATE NOT NULL,
    finishDate DATE
);

INSERT INTO 
Projects(projectName, projectType, currentRowsDone, rowTarget, startDate)
VALUES
    ('Yellow scarf', 'crochet', 20, 60, '2021-01-01');