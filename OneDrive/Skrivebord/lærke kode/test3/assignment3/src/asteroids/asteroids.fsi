module Asteroids

type Vec = float * float

module Vec =
    val add: Vec -> Vec -> Vec
    val subtract: Vec -> Vec -> Vec
    val scale: float -> Vec -> Vec
    val magnitude: Vec -> float
    val unit: float -> Vec
    val wrapAround: Vec -> Vec -> Vec -> Vec
    val angle: Vec -> float
