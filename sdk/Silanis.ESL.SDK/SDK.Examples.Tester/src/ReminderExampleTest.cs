using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class ReminderExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            ReminderExample example = new ReminderExample();
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

