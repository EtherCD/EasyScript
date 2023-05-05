<h1 align="center">
  EasyScript
  <br><br>
  <a>
    <img src="https://github.com/EtherCD/EasyScript/blob/master/logo.png?raw=true" alt="Logo" width="125" height="125">
  </a><br>
  <img src="https://img.shields.io/tokei/lines/github/EtherCD/EasyScript?style=for-the-badge" />
  <img src="https://img.shields.io/github/languages/code-size/EtherCD/EasyScript?style=for-the-badge" />
</h1>

<div align="center">
  Small programming language. With big ambitions
  <br />
  <br />
  <h1>Doc</h1>
  <a href="https://github.com/EtherCD/EasyScript/blob/master/doc/Intro.md">Introduction</a>
  <h2>Libs</h2>
  <a href="https://github.com/EtherCD/EasyScript/blob/master/doc/Math.md">Math</a><br>
  <a href="https://github.com/EtherCD/EasyScript/blob/master/doc/Sys.md">Sys</a>
  <h1>Syntaxis</h1>
</div>

  ```es
  const pi = 3.145

const angle = random(1)
const speed = random(10, 20)

var velx = cos(angle*pi*2)*speed
var vely = sin(angle*pi*2)*speed

var width = 80 * 32
var height = 15 * 32

var posx = random(width)
var posy = random(height)

var radius = random(30)

print("| Colide emulator |")
print("| Default  Params |")
print("Speed: "+speed)
print("Angle: "+angle)
print("Pos: x -> "+posx+"\n     y -> "+posy)
print("Vel: x -> "+velx+"\n     y -> "+vely)
print("AreaSize: width -> "+width+"\n          height -> "+height)
print("|  Start Program  |")

var iterator = 0
do {
    print("|  Start  Frame  |")
    print("Frame Counter: " + iterator)
    posx = posx + velx
    posy = posy + vely

    if (posx - radius < 0) {
        posx = radius
        velx = abs(velx)
    }
    if (posx + radius > width) {
        posx = width - radius
        velx = -abs(velx)
    }
    if (posy - radius < 0) {
        posy = radius
        vely = abs(vely)
    }
    if (posy + radius > height) {
        posy = height - radius
        vely = -abs(vely)
    }

    print("Pos: x -> "+posx+"\n     y -> "+posy)

    print("|   End  Frame   |")
    iterator = iterator + 1
} while (iterator < 100)
print("!  End  Program  !")
  
  ```
