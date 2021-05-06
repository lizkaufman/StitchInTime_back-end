CREATE TABLE IF NOT EXISTS Users (
    id SERIAL PRIMARY KEY,
    firstName TEXT NOT NULL,
    lastName TEXT,
    email TEXT,
    projects INT[]
);

INSERT INTO
    Users (firstName, lastName, email, projects)
VALUES
    ('Liz', 'Kaufman', 'lizkaufman92@gmail.com', ARRAY[0]);