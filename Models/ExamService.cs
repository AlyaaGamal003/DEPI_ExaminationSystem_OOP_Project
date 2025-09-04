namespace ExamSystem.Models;

    public class ExamService
    {
        private List<StudentExams> _studentExams;

        public ExamService()
        {
            _studentExams = new List<StudentExams>();
        }

        public StudentExams TakeExam(Student student, Exam exam)
        {
            if (!exam.IsStarted)
            {
                throw new Exception("Exam has not started yet.");
            }

            if (exam.Questions == null || exam.Questions.Count == 0)
            {
                throw new Exception("Exam has no questions.");
            }

            decimal totalScore = 0;

            Console.WriteLine($"\n=== Starting Exam: {exam.Title} ===");
            Console.WriteLine($"Student: {student.Name}");
            Console.WriteLine($"Total Questions: {exam.Questions.Count}");
            Console.WriteLine($"Total Marks: {exam.TotalMarks}");
            Console.WriteLine("=====================================\n");

            for (int i = 0; i < exam.Questions.Count; i++)
            {
                var question = exam.Questions[i];
                Console.WriteLine($"Question {i + 1}: {question.Title} (Marks: {question.Mark})");

                if (question is MCQ mcq)
                {
                    totalScore += HandleMCQQuestion(mcq);
                }
                else if (question is TrueFalse tf)
                {
                    totalScore += HandleTrueFalseQuestion(tf);
                }
                else if (question is Essay essay)
                {
                    totalScore += HandleEssayQuestion(essay);
                }

                Console.WriteLine();
            }

            var studentExam = new StudentExams(totalScore, student, exam);
            _studentExams.Add(studentExam);

            Console.WriteLine($"=== Exam Completed ===");
            Console.WriteLine($"Final Score: {totalScore}/{exam.TotalMarks}");
            Console.WriteLine($"Percentage: {(totalScore / exam.TotalMarks * 100):F2}%");

            return studentExam;
        }

        private decimal HandleMCQQuestion(MCQ mcq)
        {
            for (int j = 0; j < mcq.Options.Count; j++)
            {
                Console.WriteLine($"{j + 1}. {mcq.Options[j]}");
            }

            Console.Write("Your answer (enter option number): ");
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                if (mcq.CheckAnswer(answer))
                {
                    Console.WriteLine("Correct!");
                    return mcq.Mark;
                }
                else
                {
                    Console.WriteLine($"Incorrect. Correct answer was option {mcq.CorrectAnswer + 1}");
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Question skipped.");
                return 0;
            }
        }

        private decimal HandleTrueFalseQuestion(TrueFalse tf)
        {
            Console.WriteLine("True/False Question");
            Console.Write("Your answer (true/false or t/f): ");
            string input = Console.ReadLine()?.ToLower();

            bool studentAnswer;
            if (input == "true" || input == "t")
                studentAnswer = true;
            else if (input == "false" || input == "f")
                studentAnswer = false;
            else
            {
                Console.WriteLine("Invalid input. Question skipped.");
                return 0;
            }

            if (tf.CheckAnswer(studentAnswer))
            {
                Console.WriteLine("Correct!");
                return tf.Mark;
            }
            else
            {
                Console.WriteLine($"Incorrect. Correct answer was {tf.CorrectAnswer}");
                return 0;
            }
        }

        private decimal HandleEssayQuestion(Essay essay)
        {
            Console.WriteLine("Essay Question - Answer below:");
            Console.Write("Your answer: ");
            string answer = Console.ReadLine();

            Console.WriteLine("Essay submitted successfully.");
            Console.WriteLine("Note: Essay questions require manual grading.");
            
            // For demonstration, award full marks
            // In real system, this would require instructor review
            return essay.Mark;
        }

        public List<StudentExams> GetAllStudentExams()
        {
            return _studentExams;
        }

        public List<StudentExams> GetStudentExamsByStudent(int studentId)
        {
            return _studentExams.Where(se => se.Student.Id == studentId).ToList();
        }

        public List<StudentExams> GetStudentExamsByExam(int examId)
        {
            return _studentExams.Where(se => se.Exam.Id == examId).ToList();
        }
    }