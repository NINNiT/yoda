#!/usr/bin/env python3

import asyncio
import signal
import skywriter
import requests
import json

proxy_url = "http://localhost:3000/"
headers = {"content-type": "application/json"}


def send_data(payload):
    try:
        r = requests.post(proxy_url, data=json.dumps(payload), headers=headers)
    except Exception as e:
        print(e)


@skywriter.flick()
def flick(start, finish):
    payload = {}
    if start == "north":
        payload = {"action": "flick-north"}
    elif start == "south":
        payload = {"action": "flick-south"}
    elif start == "east":
        payload = {"action": "flick-east"}
    elif start == "west":
        payload = {"action": "flick-west"}

    send_data(payload)
    print("flicking", start, finish)


@skywriter.tap()
def tap(position):
    payload = {}
    if position == "center":
        payload = {"action": "tap-center"}
    elif position == "north":
        payload = {"action": "tap-north"}
    elif position == "west":
        payload = {"action": "tap-west"}
    elif position == "east":
        payload = {"action": "tap-east"}
    elif position == "south":
        payload = {"action": "tap-south"}
    send_data(payload)
    print("Tap!", position)


@skywriter.double_tap()
def doubletap(position):
    payload = {}
    if position == "center":
        payload = {"action": "doubletap-center"}
    elif position == "north":
        payload = {"action": "doubletap-north"}
    elif position == "west":
        payload = {"action": "doubletap-west"}
    elif position == "east":
        payload = {"action": "doubletap-east"}
    elif position == "south":
        payload = {"action": "doubletap-south"}
    send_data(payload)
    print("Double tap!", position)


@skywriter.touch()
def touch(position):
    payload = {}
    if position == "center":
        payload = {"action": "touch-center"}
    elif position == "north":
        payload = {"action": "touch-north"}
    elif position == "west":
        payload = {"action": "touch-west"}
    elif position == "east":
        payload = {"action": "touch-east"}
    elif position == "south":
        payload = {"action": "touch-south"}
    send_data(payload)
    print("Touch!", position)


signal.pause()
