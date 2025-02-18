# Examination System (OOP)

This **Examination System** is developed using **Object-Oriented Programming (OOP)** principles in C#. It is designed to manage different types of exams like **Practice Exam** and **Final Exam**. The system provides various functionalities including question management, exam modes, timers, notifications, user login, and subject management.

## Features

### 1. **User Login System**
   - Users (instructors and students) must log in to access the system.
   - **Instructors** have administrative privileges, such as creating exams, managing subjects, and notifying students.
   - **Students** can take exams and view their results after completing the exams.

### 2. **Question Management**
   - The system supports various **Question Types**:
     - **True or False** Questions
     - **Choose One** Questions
     - **Choose All** Questions
   - Questions are stored in separate files, with each question list having its own file.
   - Every **Question** object is logged to the file when it is added to the list.

### 3. **Exam Types**
   - **Practice Exam**: Displays correct answers after completion.
   - **Final Exam**: Does not display answers and focuses on testing the student's knowledge.
   - **Timer**:
     - **Final Exam**: 
       - The timer is enabled, and the exam automatically finishes once the time is up. 
       - The timer countdown will be shown during the exam. 
       - If the student doesn't finish in time, the exam will be automatically marked as **finished**, and the results will be submitted.
     - **Practice Exam**: 
       - The correct answers will **appear after each question** for **True/False** questions.
       - The system provides immediate feedback on whether the answer is correct or not after the student answers a question.

### 4. **Exam Modes**
   - **Starting Mode**: Exam is about to start.
   - **Queued Mode**: Exam is waiting to be started.
   - **Finished Mode**: Exam is completed.

### 5. **Subject Management**
   - The system supports defining different **Subjects**, such as Math, Science, History, etc.
   - Each **Exam** is associated with a specific subject.

### 6. **Instructor Features**
   - Instructors can manage questions, create exams, set exam timers, and notify students.
   - Instructors can choose between **Final Exam** and **Practice Exam**.
   - Instructors can set up notifications for students when the exam is in **Starting Mode**.
   - Instructors can configure the **timer** for exams, especially for **Final Exams**, where a strict timer is applied.

### 7. **Notification System**
   - When the exam is in **Starting Mode**, all students taking the subject will be notified using an event-delegate system.

## Timer Functionality in Exams

### 1. **Final Exam Timer**:
   - The **Final Exam** has a fixed timer. The timer starts when the exam begins and counts down in real-time.
   - If the timer runs out before the student finishes, the exam will **automatically finish**, and the system will display a "Time's Up!" message.
   - The student cannot continue answering questions after the timer expires.
   - **Timer behavior**:
     - Countdown will be visible during the exam.
     - The system will stop the exam automatically if the timer reaches zero.

### 2. **Practice Exam Timer**:    
   - Students can take the exam at their own pace without a time limit.    

## Getting Started

### Prerequisites

Make sure you have the following installed:
- **.NET Core SDK** (version 6 or higher)
- **Visual Studio Code** (or any C# IDE)

### How to Use

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/your-username/examination-system-oopcsharp.git

