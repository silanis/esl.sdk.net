using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class ReminderExample : SdkSample
    {
		public static void Main (string[] args)
		{
			new ReminderExample().Run();
		}

        public ReminderSchedule ReminderScheduleToCreate, ReminderScheduleToUpdate;
        public ReminderSchedule CreatedReminderSchedule, UpdatedReminderSchedule, RemovedReminderSchedule;

		override public void Execute()
		{
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
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

            ReminderScheduleToCreate = ReminderScheduleBuilder.ForPackageWithId(packageId)
                .WithDaysUntilFirstReminder(2)
                    .WithDaysBetweenReminders(1)
                    .WithNumberOfRepetitions(5)
                    .Build();

            eslClient.ReminderService.CreateReminderScheduleForPackage(ReminderScheduleToCreate);

            eslClient.SendPackage( packageId );

            CreatedReminderSchedule = eslClient.ReminderService.GetReminderScheduleForPackage(packageId);

            ReminderScheduleToUpdate = ReminderScheduleBuilder.ForPackageWithId( packageId )
                .WithDaysUntilFirstReminder( 3 )
                    .WithDaysBetweenReminders( 2 )
                    .WithNumberOfRepetitions( 10 )
                    .Build();

            eslClient.ReminderService.UpdateReminderScheduleForPackage(ReminderScheduleToUpdate);
            UpdatedReminderSchedule = eslClient.ReminderService.GetReminderScheduleForPackage(packageId);

			eslClient.ReminderService.ClearReminderScheduleForPackage(packageId);
            RemovedReminderSchedule = eslClient.ReminderService.GetReminderScheduleForPackage(packageId);
		}
	}
}

