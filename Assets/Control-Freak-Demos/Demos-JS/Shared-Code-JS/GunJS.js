#pragma strict 


@script AddComponentMenu("ControlFreak-Demos-JS/GunJS")

public class GunJS extends MonoBehaviour 
{
public var	shotParticles	: ParticleSystem;

public var	shotSound 		: AudioClip;
public var 	emptySound		: AudioClip;

public var	reloadSound		: AudioClip;

private var isFireing		: boolean;	
public var	shotInterval	: float	= 0.175f;	
	
private var	lastShotTime 	: float;	
	
public var	unlimitedAmmo	: boolean	= false;
public var	bulletCapacity	: int	= 40;
public var	bulletCount		: int	= 40;


// --------------------
function  Start() : void
	{
	this.isFireing = false;
	}


// -----------------------
public function SetTriggerState(fire : boolean) : void
	{	
	if (fire != this.isFireing)
		{
		this.isFireing = fire;
		
		if (fire)
			{
			// Fire first bullet...

			this.FireBullet();	
			}
		}
	}

	

// --------------------
function FixedUpdate() : void 
	{
	if (this.isFireing)
		this.FireBullet();
	
	}

 

// ------------------	
public function Reload() : void
	{
	this.bulletCount = this.bulletCapacity;
	
	if ((this.GetComponent.<AudioSource>() != null) && (this.reloadSound != null))
		{
		this.GetComponent.<AudioSource>().loop = false;
		this.GetComponent.<AudioSource>().PlayOneShot(this.reloadSound);
		}
	}


// ---------------------
private function FireBullet() : void
	{
	if ((Time.time - this.lastShotTime) >= this.shotInterval)
		{
		this.lastShotTime = Time.time;
	

		// Shoot...
			
		
		if (this.unlimitedAmmo || (this.bulletCount > 0))
			{
			if (!this.unlimitedAmmo)
				--this.bulletCount;	

			// Emit particles...
				
			if ((this.shotParticles != null) )
				{
				this.shotParticles.Play();
				}
	
	
			// Play sound...
	
			if ((this.GetComponent.<AudioSource>() != null) && (this.shotSound != null)) // && (!this.shotSoundLooped))
				{	
				this.GetComponent.<AudioSource>().loop = false;
				this.GetComponent.<AudioSource>().PlayOneShot(this.shotSound);	
				}
			}

		// No bullets left!!

		else
			{
			// Play sound...
	
			if ((this.GetComponent.<AudioSource>() != null) && (this.emptySound != null)) // && (!this.emptySoundLooped))
				{	
				this.GetComponent.<AudioSource>().loop = false;
				this.GetComponent.<AudioSource>().PlayOneShot(this.emptySound);	
				}
			}

		}
	}

}
