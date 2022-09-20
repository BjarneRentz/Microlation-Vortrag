var ms1 = new Microservice();
var ms2 = new Microservice{
    Routes = {
        new Route{ Url = "Users", Faults = new TimeoutFault()}
    }
};
var policy = new Retry();
var call = ms1.call(ms2, 
	new CallConfig{ Route = "Users", Policies = policy, Interval = TimeSpan.FromSeconds(1)});