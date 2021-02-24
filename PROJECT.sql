CREATE DATABASE surveysDB;
USE surveysDB;
CREATE TABLE users
(User_name VARCHAR(30) NOT NULL PRIMARY KEY,
User_password VARCHAR(10) NOT NULL
);

CREATE TABLE surveys
(Id INT AUTO_INCREMENT PRIMARY KEY,
User_name VARCHAR(80) NOT NULL,
`Name` VARCHAR(80) NOT NULL,
Survey_code VARCHAR(10),
 CONSTRAINT fk_surveys_users FOREIGN KEY(User_name)
 REFERENCES users(User_name)
 );
 CREATE TABLE input_types
 (Id INT AUTO_INCREMENT PRIMARY KEY,
 Input_type_name VARCHAR(80) NOT NULL
 );
 CREATE TABLE questions
 (Id INT AUTO_INCREMENT PRIMARY KEY,
 Input_type_id INT NOT NULL,
 Surveys_id INT NOT NULL,
 Question_name VARCHAR(255) NOT NULL,
  CONSTRAINT fk_questions_surveys FOREIGN KEY(Surveys_id)
  REFERENCES surveys(`Id`),
  CONSTRAINT fk_questions_input_types FOREIGN KEY(Input_type_id)
  REFERENCES input_types(Id)
 );
 
 CREATE TABLE text_answers
 (Id INT AUTO_INCREMENT PRIMARY KEY,
 User_name VARCHAR(80) NOT NULL,
 Question_id INT NOT NULL,
 Answer TEXT NOT NULL,
 CONSTRAINT fk_text_answers_users FOREIGN KEY(User_name)
 REFERENCES users(`User_name`),
 CONSTRAINT fk_text_answers_questions FOREIGN KEY(Question_id)
 REFERENCES questions(Id));
 CREATE TABLE option_choices
 (Id INT AUTO_INCREMENT PRIMARY KEY,
 Question_id INT NOT NULL,
 Option_choices_name VARCHAR(80) NOT NULL,
 CONSTRAINT fk_option_choices_questions FOREIGN KEY(Question_id)
 REFERENCES questions(Id));
 CREATE TABLE answers
 (Id INT AUTO_INCREMENT PRIMARY KEY,
User_name VARCHAR(80) NOT NULL,
Question_option_id INT NOT NULL,
CONSTRAINT fk_answers_users FOREIGN KEY(User_name)
REFERENCES users(User_name),
CONSTRAINT fk_answers_option_choices FOREIGN KEY(Question_option_id)
REFERENCES option_choices(Id));
