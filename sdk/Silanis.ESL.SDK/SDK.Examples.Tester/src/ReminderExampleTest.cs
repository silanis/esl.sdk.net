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

            Assert.IsNotNull(example.CreatedReminderSchedule);
            Assert.AreEqual(example.PackageId.Id, example.CreatedReminderSchedule.PackageId.Id);
            Assert.AreEqual(example.ReminderScheduleToCreate.DaysUntilFirstReminder, example.CreatedReminderSchedule.DaysUntilFirstReminder);
            Assert.AreEqual(example.ReminderScheduleToCreate.DaysBetweenReminders, example.CreatedReminderSchedule.DaysBetweenReminders);
            Assert.AreEqual(example.ReminderScheduleToCreate.NumberOfRepetitions, example.CreatedReminderSchedule.NumberOfRepetitions);

            Assert.IsNotNull(example.UpdatedReminderSchedule);
            Assert.AreEqual(example.PackageId.Id, example.UpdatedReminderSchedule.PackageId.Id);
            Assert.AreEqual(example.UpdatedReminderSchedule.DaysUntilFirstReminder, example.UpdatedReminderSchedule.DaysUntilFirstReminder);
            Assert.AreEqual(example.UpdatedReminderSchedule.DaysBetweenReminders, example.UpdatedReminderSchedule.DaysBetweenReminders);
            Assert.AreEqual(example.UpdatedReminderSchedule.NumberOfRepetitions, example.UpdatedReminderSchedule.NumberOfRepetitions);

            Assert.IsNull(example.RemovedReminderSchedule);
        }
    }
}

