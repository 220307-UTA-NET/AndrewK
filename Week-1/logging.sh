#!/usr/bin/bash

today=$(date +"%Y-%m-%d")
now=$(date +"%T")

if [ -e ${today}.txt ];then
	echo "Script run at ${now}" >> ${today}.txt
else
	echo "Starting file for ${today} at ${now}" >> ${today}.txt
fi
