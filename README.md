# 2D Cannon Shooting Game
## Overall Design
For the game terrain, this will be a 2D profile of an uneven, but more-or-less flat terrain, with a central mound, as shown below, and bounded on the left by a vertical wall.

![image](https://user-images.githubusercontent.com/68981504/148133772-20c50e71-43a8-40cf-8d27-6be130307937.png)

The ground (which includes the central mound) shape is randomized for each playthrough, but still overall similar, which is implemented and used both midpoint-bisection and 1D Perlin noiseto produce a profile that has both coarse and fine-grain detail while retaining the overall general shape.

On the right side of the screen is a player-controlled cannon, directed toward the left side of the screen. The cannon can be fired, emitting cannonballs that are drawn as small circles, with motion modeled using projectile physics, incorporating initial velocity, barrel angle, gravity. Cannonballs are not affected by wind,  but do include some amount of friction so they eventually stop moving.

Determine appropriate gravity and a range of barrel velocities (assume cannonballs have unit mass). It should be possible with some combination of angle and velocity for cannonballs to hit the mound directly, and to shoot up and over it to land on the terrain on the other side of the mound. Ensure the cannonball motion is easily visible to a human observer.

Pressing the spacebar fires the cannon. Barrel elevation should be controlled within a 90◦ range (ie ranging between pointing horizontally and pointing straight up), increasing with the up-arrow and decreasing by a down-arrow press, while muzzle velocity is increased/decreased by left/right arrows. The current muzzle velocity is also represented on the top of the screen.

To the left of the cannon is an invisible wall. Cannonballs that go offscreen in any way, or which contact the invisible wall from the left side, or which end up stationary for an extended period disappear. Cannonballs that encounter the mound, ground, or other cannonballs, however, collide with some reasonable response. 
On the left side of the terrain are some number of insects as shown below. Insects are spawned at random locations left of the mound, and gently float around using just random motion. Insects do not interact/collide with each other, and may thus overlap. Any insects which encounter the invisible wall in front of the cannon or which go offscreen at the top are despawned, and replaced by a new, fresh insect. The motion of the insects is modeled by the Verlet intergration with 14 points and some restrictions.

![image](https://user-images.githubusercontent.com/68981504/148134213-5a9c27c4-c597-4659-9cb9-ec1fcec4faf3.png)

Insects can collide with the ground, and they so smart that they will not collide with cannonballs, but they will escape from them. Cannonballs are not themselves affected by collisions with an insect.

Left of the mound added 3 sources of rising air. Each source generates a vertical column of air moving upward at a random speed. The air-speed of a column changes (instantaneously) about every 2s, and range between 0 and the speed would push a point from the bottom to the top of the scene in about 0.5s. This rising air does not affect cannonballs, but does affect insects.
