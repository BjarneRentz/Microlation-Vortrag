var caller = new Microservice("Caller");
var target = new Microservice("Target")
{
	Routes = new List<IRoute>
	{
		new Route<int> { Url = "Target", Faults = faultPolicy,Value = () => 3 }
	}
};
caller.Call(target, new CallOptions<int>
{
	Route = "Target",
	Interval = _ => TimeSpan.FromMilliseconds(500),
	Policies = Policy<int>.Handle<TimeoutRejectedException>().Retry(retries)
		.Wrap(Policy.Timeout<int>(TimeSpan.FromMilliseconds(timeout)))
});