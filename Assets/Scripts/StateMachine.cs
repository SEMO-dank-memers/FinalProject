//Here be the Enemy creation tool aka StateMachine
public class Enemy{
	enum State { UNASSIGNED, IDLE, THROW, ATTACK, RUN, CROUCH, JUMP, PANIC, FLY, CHARGE };
	enum Role { UNASSIGNED, BRAWLER, THROWER, TROLL, NINJA, BIRD };
	State currentState {get; set;}
	Role role {get; set;}
	float bravery; //used with fuzzy logic to help determine the State, for variation purposes
	Enemy() = default;
	Enemy(State state, Role role, float b){ 
		this.currentState = state;
		this.role = role;
		this.bravery = b;
	}
	float setBravery(Role role);
}

float setBravery(Role role){
	//threshold values are set according the Role
	//maybe use values of 0 - 9.99 to keep simple
	Random random = new Random();
	double randomSelector = random.NextDouble(0,10.0);
	double lowerThreshold, upperThreshold;
	switch(role){
		case BRAWLER:
			lowerThreshold = 5.0;
			upperThreshold = 7.0;
			break;
		case THROWER:
			lowerThreshold = 5.0;
			upperThreshold = 7.0;
			break;
		case TROLL:
			lowerThreshold = 5.0;
			upperThreshold = 7.0;
			break;
		case NINJA:
			lowerThreshold = 5.0;
			upperThreshold = 7.0;
			break;
		case BIRD:
			lowerThreshold = 5.0;
			upperThreshold = 7.0;
			break;
		default:
			lowerThreshold = 4.0;
			upperThreshold = 7.0;
			break;
	}
	//call upon chosen fuzzy function using the above doubles
}


//Here lies the fuzzy membership functions, we may not need them all but here they be
double FuzzyAND(double A, double B) return MIN(A, B);
double FuzzyOR(double A, double B) return MAX(A, B);
double FuzzyNOT(double A) return 1.0 - A;
double FuzzyGrade(double value, double x0, double x1){
	double result = 0;
	double x = value;
	if(x <= x0) result = 0;
	else if(x >= x1) result = 1;
	else result = (x/(x1-x0))-(x0/(x1-x0));
	return result;
}
double FuzzyReverseGrade(double value, double x0, double x1){
	double result = 0;
	double x = value;
	if(x <= x0) result = 1;
	else if(x >= x1) result = 0;
	else result = (-x/(x1-x0))+(x1/(x1-x0));
	return result;
}
double FuzzyTriangle(double value, double x0, double x1, double x2){
	double result = 0;
	double x = value;
	if(x <= x0) result = 0;
	else if(x == x1) result = 1;
	else if((x>x0) && (x<x1)) result = (x/(x1-x0))-(x0/(x1-x0));
	else result = (-x/(x2-x1))+(x2/(x2-x1));
	return result;
}
double FuzzyTrapezoid(double value, double x0, double x1, double x2, double x3){
	double result = 0;
	double x = value;
	if(x <= x0) result = 0;
	else if((x>=x1) && (x<=x2)) result = 1;
	else if((x>x0) && (x<x1)) result = (x/(x1-x0))-(x0/(x1-x0));
	else result = (-x/(x3-x2))+(x3/(x3-x2));
	return result;
}