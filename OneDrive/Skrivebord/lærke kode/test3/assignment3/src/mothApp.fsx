open System
open Asteroids

// Define a Moth type
type Moth(pos: Vec, hdng: float) =
    let mutable position = pos
    let mutable heading = hdng

    member this.Heading = heading
    member this.Pos = position
    member this.Draw () = 
        let mothShape = Circle(5.0, SolidColor(Color.FromRGB(255, 255, 0)))
        Transform.translate (fst position) (snd position) mothShape
    
    member this.Move distance =
        position <- Vec.add position (Vec.scale distance (Vec.unit heading))
        position <- Vec.wrapAround position (0.0, 0.0) (800.0, 600.0)

    member this.Update isLightOn lightPos =
        if isLightOn then
            heading <- Vec.angle (Vec.subtract lightPos position)
        else
            heading <- heading + (Random().NextDouble() * 20.0 - 10.0) |> radians

// Example simulator logic
let runSimulator () =
    let moths = [for i in 1..5 -> Moth((float i * 100.0, float i * 100.0), 0.0)]
    let mutable isLightOn = false
    let lightPosition = (400.0, 300.0)

    // Update logic for the simulation
    let update () =
        moths |> List.iter (fun moth -> moth.Update isLightOn lightPosition)
        () // Explicitly return unit

    // Draw logic for the simulation
    let draw () =
        moths |> List.map (fun moth -> moth.Draw ()) |> Group // Return the Group

    // Main simulation loop (if needed for integration later)
    update, draw // Return functions for use in the simulation loop