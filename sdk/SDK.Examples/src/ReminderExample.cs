using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class ReminderExample : SDKSample
    {
		public static void Main (string[] args)
		{
			new ReminderExample().Run();
		}

        public ReminderSchedule reminderScheduleToCreate, reminderScheduleToUpdate;
        public ReminderSchedule createdReminderSchedule, updatedReminderSchedule, removedReminderSchedule;

		override public void Execute()
		{
            DocumentPackage superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
				.WithSigner( SignerBuilder.NewSignerWithEmail( email1 )
					.WithFirstName( "Patty" )
					.WithLastName( "Galant" ) )
				.WithDocument( DocumentBuilder.NewDocumentNamed( "First Document" )
					.FromStream( fileStream1, DocumentType.PDF )
					.WithSignature( SignatureBuilder.SignatureFor( email1 )
						.OnPage( 0 )
						.AtPosition( 100, 100 ) ) )
				.Build();

			packageId = eslClient.CreatePackage( superDuperPackage );

            reminderScheduleToCreate = ReminderScheduleBuilder.ForPackageWithId(packageId)
                .WithDaysUntilFirstReminder(2)
                    .WithDaysBetweenReminders(1)
                    .WithNumberOfRepetitions(5)
                    .Build();

            eslClient.ReminderService.CreateReminderScheduleForPackage(reminderScheduleToCreate);

            eslClient.SendPackage( packageId );

            createdReminderSchedule = eslClient.ReminderService.GetReminderScheduleForPackage(packageId);

            reminderScheduleToUpdate = ReminderScheduleBuilder.ForPackageWithId( packageId )
                .WithDaysUntilFirstReminder( 3 )
                    .WithDaysBetweenReminders( 2 )
                    .WithNumberOfRepetitions( 10 )
                    .Build();

            eslClient.ReminderService.UpdateReminderScheduleForPackage(reminderScheduleToUpdate);
            updatedReminderSchedule = eslClient.ReminderService.GetReminderScheduleForPackage(packageId);

			eslClient.ReminderService.ClearReminderScheduleForPackage(packageId);
            removedReminderSchedule = eslClient.ReminderService.GetReminderScheduleForPackage(packageId);
		}
	}
}

