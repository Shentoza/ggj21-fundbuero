# UnitySkeleton
Raw skeleton for my Unity3D projects.

Including:
* Structure for Assets/
* proper Git set-up
	* Editor Settings
	* .gitignore
	* .gitattributes



# Usage
To get started simply use the following command to clone the repository.

To clone master (up-to-date Unity version):

	git clone git@github.com:HatiEth/UnitySkeleton.git --origin skeleton [<target_directory>]

To clone any provided version (5.0 onwards):

	git clone git@github.com:HatiEth/UnitySkeleton.git -b [<version>] --origin skeleton [<target_directory>]

You have to add your repository as remote and bend the upstream to it if you want to continue working on the master branch.

	git branch --set-upstream-to=[<remote-branch>]

**OR** use

	git push -u

to say so as you push.

## Updating the skeleton

To update your current skeleton use the skeleton remote to access any changes.

# License
Feel free to use or fork.
