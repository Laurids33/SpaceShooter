# SpaceShooter
## Installation
### NixOS
Add following codeblock to your `configuration.nix`.
```nix
  environment.systemPackages = with pkgs; [
    # spaceshooter
    (import (builtins.fetchurl {
        url = "https://github.com/Laurids33/SpaceShooter/releases/download/releas_v1.00.01/package.nix";
        sha256 = "0lxvw1lxk52jzv154k2g59hdx6lzfwbkj1rrws6psrj43f2dgf0g";
      }) {
        inherit pkgs;
        inherit (pkgs) stdenv fetchurl lib unzip steam-run;
      })

  ];
```
Use either the .desktop file or run `spaceshooter`.
