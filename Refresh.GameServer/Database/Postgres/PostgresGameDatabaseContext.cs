using System.Reflection;
using Bunkum.EntityFrameworkDatabase;
using Microsoft.EntityFrameworkCore;
using Realms;
using Refresh.GameServer.Authentication;
using Refresh.GameServer.Time;
using Refresh.GameServer.Types;
using Refresh.GameServer.Types.Activity;
using Refresh.GameServer.Types.Assets;
using Refresh.GameServer.Types.Comments;
using Refresh.GameServer.Types.Levels;
using Refresh.GameServer.Types.Levels.SkillRewards;
using Refresh.GameServer.Types.Notifications;
using Refresh.GameServer.Types.Photos;
using Refresh.GameServer.Types.Relations;
using Refresh.GameServer.Types.Report;
using Refresh.GameServer.Types.UserData;
using Refresh.GameServer.Types.UserData.Leaderboard;

namespace Refresh.GameServer.Database.Postgres;

#nullable disable

public class PostgresGameDatabaseContext(Action<DbContextOptionsBuilder> configureAction) : BunkumDbContext(configureAction), IGameDatabaseContext
{
    private DbSet<GameUser> GameUsers { get; set; }
    private DbSet<GameLocation> GameLocations { get; set; }
    private DbSet<UserPins> UserPins { get; set; }
    private DbSet<Token> Tokens { get; set; }
    private DbSet<GameLevel> GameLevels { get; set; }
    private DbSet<GameSkillReward> GameSkillRewards { get; set; }
    private DbSet<GameComment> GameComments { get; set; }
    private DbSet<FavouriteLevelRelation> FavouriteLevelRelations { get; set; }
    private DbSet<QueueLevelRelation> QueueLevelRelations { get; set; }
    private DbSet<FavouriteUserRelation> FavouriteUserRelations { get; set; }
    private DbSet<PlayLevelRelation> PlayLevelRelations { get; set; }
    private DbSet<UniquePlayLevelRelation> UniquePlayLevelRelations { get; set; }
    private DbSet<RateLevelRelation> RateLevelRelations { get; set; }
    private DbSet<Event> Events { get; set; }
    private DbSet<GameSubmittedScore> GameSubmittedScores { get; set; }
    private DbSet<GameAsset> GameAssets { get; set; }
    private DbSet<GameNotification> GameNotifications { get; set; }
    private DbSet<GamePhoto> GamePhotos { get; set; }
    private DbSet<GamePhotoSubject> GamePhotoSubjects { get; set; }
    private DbSet<GameIpVerificationRequest> GameIpVerificationRequests { get; set; }
    private DbSet<GameAnnouncement> GameAnnouncements { get; set; }
    private DbSet<QueuedRegistration> QueuedRegistrations { get; set; }
    private DbSet<EmailVerificationCode> EmailVerificationCodes { get; set; }
    private DbSet<RequestStatistics> RequestStatistics { get; set; }
    // private DbSet<SequentialIdStorage> SequentialIdStorages { get; set; }
    // private DbSet<GameReport> GameReports { get; set; }
    // private DbSet<InfoBubble> InfoBubbles { get; set; }
    // private DbSet<Marqee> Marqees { get; set; }
    // private DbSet<Player> Players { get; set; }
    // private DbSet<Rect> Rects { get; set; }
    // private DbSet<ScreenElements> ScreenElements { get; set; }
    // private DbSet<ScreenRect> ScreenRects { get; set; }
    // private DbSet<Slot> Slots { get; set; }

    private DbSet<T> GetSetFromType<T>() where T : class
    {
        PropertyInfo property = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(p => p.CanRead)
            .First(p => p.PropertyType == typeof(DbSet<T>));

        return (DbSet<T>)property.GetValue(this);
    }
    
    public IDateTimeProvider Time { get; }
    #nullable enable
    public void AddSequentialObject<T>(T obj, IList<T>? list, Action? writtenCallback = null) where T : class, IRealmObject, ISequentialId
    {
        throw new NotImplementedException();
    }
    #nullable disable

    public void Refresh()
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> All<T>() where T : class, IRealmObject
    {
        return this.GetSetFromType<T>().AsQueryable();
    }

    public void Write(Action func)
    {
        throw new NotImplementedException();
    }

    public void Add<T>(T obj, bool update = false) where T : class, IRealmObject
    {
        throw new NotImplementedException();
    }

    public void AddRange<T>(IEnumerable<T> list, bool update = false) where T : class, IRealmObject
    {
        throw new NotImplementedException();
    }

    public new void Remove<T>(T obj) where T : class, IRealmObject
    {
        throw new NotImplementedException();
    }

    public void RemoveRange<T>(IQueryable<T> list) where T : class, IRealmObject
    {
        throw new NotImplementedException();
    }

    public void RemoveAll<T>() where T : class, IRealmObject
    {
        throw new NotImplementedException();
    }
}