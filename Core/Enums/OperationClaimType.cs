using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public enum OperationClaimType
    {
        // User Management
        Admin,
        UserView,
        UserCreate,
        UserUpdate,
        UserDelete,

        // Project Management
        ProjectView,
        ProjectCreate,
        ProjectUpdate,
        ProjectDelete,

        // Task Management
        TaskView,
        TaskCreate,
        TaskUpdate,
        TaskDelete,

        // Chat & Message Management
        MessageView,
        MessageSend,
        MessageDelete,
        ChatRoomCreate,
        ChatRoomDelete,

        // Reporting & Analysis
        ReportView,
        ReportGenerate,

        // System Management
        SettingsView,
        SettingsUpdate,

        // Notification Management
        NotificationView,
        NotificationSend,
        NotificationDelete
    }
}