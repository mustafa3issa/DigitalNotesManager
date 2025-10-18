# 📝 Digital Notes Manager

**Digital Notes Manager** is a modern Windows Forms application built with **.NET** and **Entity Framework Core**, designed to help users easily create, edit, organize, and manage personal notes — with categories, reminders, and statistics.

---

## 🚀 Features

### 🌟 Core Features
- **User Authentication** – Secure login and registration for each user.
- **MDI Interface** – Manage multiple note windows at once.
- **Rich Text Editing** – Supports bold, italic, underline, and color formatting.
- **Categories** – Organize notes using a custom `CategorySelector` control.
- **Reminders** – Automatic notification system for due reminders.
- **File Operations** – Save and load notes using `OpenFileDialog` and `SaveFileDialog`.
- **Search & Filter** – Quickly find notes by title, content, or category.
- **Notes List View** – Manage and sort all notes in a `DataGridView`.
- **MenuStrip Shortcuts** – File, Edit, View, and Help options for smooth navigation.

---

## 📊 Bonus Feature: Statistics Dashboard

The **StatisticsForm** provides visual insights into user activity:
- 📅 **Notes per Month** – Column chart showing notes creation trends.
- 🗂️ **Notes per Category** – Pie chart displaying note distribution.
- Built using **System.Windows.Forms.DataVisualization.Charting**.

---

## 🧠 Technical Overview

### 🧩 Tech Stack
- **Frontend/UI:** Windows Forms (.NET 8)
- **Backend:** Entity Framework Core (Code-First)
- **Database:** SQL Server LocalDB
- **Language:** C#
- **Architecture:** MDI + Layered Data/Helper structure

### 🗃️ Database Schema
**Users**
| Column | Type | Description |
|--------|------|-------------|
| UserID | int | Primary Key |
| Username | string | User’s name |
| Password | string | Hashed password |

**Notes**
| Column | Type | Description |
|--------|------|-------------|
| NoteID | int | Primary Key |
| Title | string | Note title |
| Content | string (RTF) | RichText content |
| Category | string | Note category |
| CreatedDate | DateTime | Creation timestamp |
| ReminderDate | DateTime | Optional reminder date |
| UserID | int | Foreign Key → User |

---

## 🧩 Custom Components

### 🎛️ `CategorySelector`
A custom `UserControl` that combines a ComboBox with a custom event.

Used in both Note Editor and Notes List for dynamic category updates.

### 🔔 Reminder System

A background `Timer` in `MainForm` checks reminders every minute.
If a note’s `ReminderDate` is due, a notification message appears.

---

## ⚙️ Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/mustafa3issa/DigitalNotesManager.git
   ```
2. Open the solution in **Visual Studio 2022+**.
3. Update the connection string in `NotesDbContext.cs` if needed.
4. Run the following command to apply migrations:

   ```bash
   Update-Database
   ```
5. Start the application.

---

## 🧪 Future Enhancements

* 🔗 **SignalR Reminders:** Real-time notifications across sessions.
* 🔐 **Note Encryption:** User-level privacy protection.
* ☁️ **Cloud Sync:** Backup notes using Azure or Firebase.

---

## 👤 Author

**Mustafa Issa**
Full Stack Developer (.NET Track) – ITI Scholarship 2025

📅 **Version:** `v0.9.0-beta`
🧱 Built with ❤️ using .NET 8 & EF Core

---

## 📜 License

This project is open-source and available under the [MIT License](LICENSE).

---

```

