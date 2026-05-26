using Hangfire.Common;
using Hangfire.States;
using Hangfire.Storage;
using System;

public class ShortExpirationFilter : JobFilterAttribute, IApplyStateFilter
{
    public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
    {
        // Chỉnh thời gian sống của Job thành công là 1 tiếng
        context.JobExpirationTimeout = TimeSpan.FromMinutes(1);
    }
    public void OnStateUnapplied(ApplyStateContext context, IWriteOnlyTransaction transaction) { }
}