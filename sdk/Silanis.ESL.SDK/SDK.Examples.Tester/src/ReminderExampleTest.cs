using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class ReminderExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new ReminderExample();
            example.Run();

            Assert.IsNotNull(example.createdReminderSchedule);
            Assert.AreEqual(example.PackageId.Id, example.createdReminderSchedule.PackageId.Id);
            Assert.AreEqual(example.reminderScheduleToCreate.DaysUntilFirstReminder, example.createdReminderSchedule.DaysUntilFirstReminder);
            Assert.AreEqual(example.reminderScheduleToCreate.DaysBetweenReminders, example.createdReminderSchedule.DaysBetweenReminders);
            Assert.AreEqual(example.reminderScheduleToCreate.NumberOfRepetitions, example.createdReminderSchedule.NumberOfRepetitions);

            Assert.IsNotNull(example.updatedReminderSchedule);
            Assert.AreEqual(example.PackageId.Id, example.updatedReminderSchedule.PackageId.Id);
            Assert.AreEqual(example.updatedReminderSchedule.DaysUntilFirstReminder, example.updatedReminderSchedule.DaysUntilFirstReminder);
            Assert.AreEqual(example.updatedReminderSchedule.DaysBetweenReminders, example.updatedReminderSchedule.DaysBetweenReminders);
            Assert.AreEqual(example.updatedReminderSchedule.NumberOfRepetitions, example.updatedReminderSchedule.NumberOfRepetitions);

            Assert.IsNull(example.removedReminderSchedule);
        }
    }
}

