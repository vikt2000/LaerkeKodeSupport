
module Asteroids

type Vec = { x: float; y: float }

let unit angle = { x = cos angle; y = sin angle }

let add v1 v2 = { x = v1.x + v2.x; y = v1.y + v2.y }

let scale v scalar = { x = v.x * scalar; y = v.y * scalar }

let angle v = atan2 v.y v.x

let wrapAround (v: Vec) (minX, minY) (maxX, maxY) =
    let wrap x min max = if x < min then max elif x > max then min else x
    { x = wrap v.x minX maxX; y = wrap v.y minY maxY }

let sqrt (x: float) = System.Math.Sqrt(x) 
