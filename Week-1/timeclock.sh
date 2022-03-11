#!/usr/bin/bash

echo "Running timeclock.sh..."

# Check if ClockInOut.txt exists
filename=ClockInOut.txt
# Remove file if exists
if [[ -f $filename ]]; then
	rm -i $filename
	#Check if the file is removed or not
	if [[ -f $filename ]]; then
		echo "$filename is not removed."
	else
		echo "$filename is removed."
	fi
else
	echo "File does not exist."
fi

# Create arrays
EmployeeNames=()
EmployeeTimes=()

# Not needed
# Create counter variable
#count=0

# While loop to get user input
while [ true ]; do

	# User prompt
	read -p "Enter name: (Type 'stop' to stop:) " input
	echo $input

	# Print timestamp
#	timestamp=$(date +"%Y-%m-%d--%T")
	timestamp=$(date +"%F--%T")
	echo "Current timestamp: $timestamp"

	# Exit condition
	if [[ ${input^^} == "STOP" ]]; then
		break
	# If input is an empty string
	elif [[ -z $input ]]; then
		echo "Empty string found. Please try again"
	else
		# Append input and timestamp into a txt file
		#echo $input + " " + $timestamp >> ./ClockInOut.txt

		# Append array
		EmployeeNames+=($input)
		EmployeeTimes+=($timestamp)

		# Not needed
		# Increment counter
		#count+=1

		# Sleep
		sleep 1
	fi
done

# Append arrays values into a txt file
# Have to put -- before %T in timestamp to make it into a single string
# Empty space messes up with either echo? or for loop?
for value in ${EmployeeNames[@]}; do
	echo $value ${EmployeeTimes[$value]} >> ./ClockInOut.txt
done

# Append to txt with a space but no newline
#for value in ${EmployeeNames[@]}; do
#	echo -n $value ' ' >> ./ClockInOut.txt
#done

echo "Exiting timeclock.sh"
