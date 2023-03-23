using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLevel4 : SpawnerTemplate
{
    // Start is called before the first frame update
    void Start()
    {
        /* 0 und - = Leer
         * 1 = Waterdrop
         * 2 = wood
         * 3 = stone
         * 6 = healthpickup
         * 9 = storycoin
         */
        level = new string[]
        {
            "---------------------",
            "---------------------",
            "-------------333-----",
            "333----------333-----",
            "333----------333-----",
            "333---333------------",
            "------333---333------",
            "------333---333------",
            "------------333------",
            "--333----------------",
            "--333----333------333",
            "--333----333------333",
            "---------333------333",
            "---------------------",
            
            "22222----------------",
            "---------------------",
            "--------------2222222",
            "---------------------",
            "-------22222222------",
            "---------------------",
            "222------------------",
            "---------------------",
            "33333-----------33333",
            "3-6-3-----------3-6-3",
            "3---3-----------3---3",
            "---------------------",
            "---------------------",
            "-----2222222---------",
            "---------------------",
            "---------------------",
            "-------------22222222",
            "---------------------",
            "---------------------",
            "222222222------------",
            "---------------------",

            "---------------------",
            "---------------------",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "---------------------",
            "---------------------",
            "---------------------",
            "---------------------",
            "---------------------",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "---------------------",
            "---------------------",
            "---------------------",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",

            "---------------------",
            "------333------------",
            "------333----333-----",
            "333---333----333-----",
            "333----------333---33",
            "333---333----------33",
            "------333---333----33",
            "------333---333------",
            "------------333------",
            "--333----------------",
            "--333----333----33333",
            "--333----333----33333",
            "---------333----33333",
            "---------------------",



            "2222222--------------",
            "---------------------",
            "22------------2222222",
            "---------------------",
            "-----2222222222------",
            "---------------------",
            "222------------222222",
            "---------------------",
            "33333-----------33333",
            "3-6-3-----------3-9-3",
            "3---3-----------3---3",
            "3---3-----------3---3",
            "-----2222222---------",
            "---------------------",
            "---------------------",
            "22-----------22222222",
            "---------------------",
            "---------------------",
            "222222222------------",
            "----------------22222",


            "---------------------",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "---------------------",
            "---------------------",
            "---------------------",
            "---------------------",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "---------------------",
            "---------------------",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",


            "---------------------",
            "------3333-----------",
            "------3333---333-----",
            "333---3333---333-----",
            "333----------333---33",
            "333---333----------33",
            "------333---3333---33",
            "------333---3333-----",
            "------------3333-----",
            "--3333---------------",
            "--3333---333----33333",
            "--3333---333----33333",
            "---------333----33333",
            "---------------------",


            "222222222-----------2",
            "---------------------",
            "2222---------22222222",
            "---------------------",
            "-----2222222222222---",
            "---------------------",
            "22222----------222222",
            "---------------------",
            "33333-----------33333",
            "3-6-3-----------3-9-3",
            "3-6-3-----------3---3",
            "3---3-----------3---3",
            "3--212222222----3---3",
            "---------------2222--",
            "------222------------",
            "22-----------22222222",
            "---------------------",
            "---------------------",
            "22222222222----------",
            "----------------22222",


            "---------------------",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "---------------------",
            "---------------------",
            "---------------------",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "---------------------",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",


            "---------------------",
            "-----33333-----------",
            "-----33333---3333----",
            "333--33333---3333----",
            "333----------3333-333",
            "333--3333---------333",
            "-----3333--33333--333",
            "-----3333--33333-----",
            "-----------33333-----",
            "-33333--3333---------",
            "-33333--3333----33333",
            "-33333--3333----33333",
            "--------3333----33333",
            "---------------------",

            "222222222222--------2",
            "---------------------",
            "22222222-----22222222",
            "---------------------",
            "--2222222222222222---",
            "---------------------",
            "222222222------222222",
            "333333---------333333",
            "333333---------333333",
            "3-6-33---------33-9-3",
            "3-6-33---------33---3",
            "3---33---------33---3",
            "3--233222222---33---3",
            "3---33---------332223",
            "--2222222------------",
            "22-----------22222222",
            "-----222-------------",
            "---------------------",
            "22222222222----------",
            "------------222222222",

            "---------------------",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "---------------------",
            "---------------------",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",

            "---------------------",
            "-----33333-----------",
            "-----33333--33333----",
            "3333-33333--33333----",
            "3333--------33333-333",
            "3333-33333--------333",
            "3333-33333-33333--333",
            "-----33333-33333-----",
            "-----------33333-----",
            "-333333-3333---------",
            "-333333-3333--3333333",
            "-333333-3333--3333333",
            "--------3333--3333333",
            "---------------------",

            "333333333333333333333",
            "222222222222222-----2",
            "---------------------",
            "222222222--2222222222",
            "---------------------",
            "-2222222222222222222-",
            "---------------------",
            "222222222---223333333",
            "333333--------3------",
            "333333--------3-33333",
            "3-6-33--------3-3---3",
            "3-6-33--------3-3-9-3",
            "3---33--------3-3---3",
            "322233222222--3-33333",
            "3---33--------3------",
            "--2222222-----3333333",
            "22-----------22222222",
            "-----222222----------",
            "---------------222---",
            "22222222222----------",
            "------------222222222",


            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",


            "---------------------",
            "-----33333-----------",
            "3333-33333-333333----",
            "3333-33333-333333----",
            "3333-------333333-333",
            "3333-333333-------333",
            "3333-333333333333-333",
            "3333-333333333333-333",
            "-----------333333----",
            "3333333-3333---------",
            "3333333-3333--3333333",
            "3333333-3333--3333333",
            "3333333-3333--3333333",
            "---------------------",


            "222222222222222---222",
            "222222---------------",
            "222222222--2222222222",
            "-------------22222---",
            "-2222222222222222222-",
            "---------------------",
            "222222222---222222222",
            "--222222-------------",
            "-22222222222--2222222",
            "--------------2222222",
            "--2222222------------",
            "22--222222---22222222",
            "-----222222----------",
            "---------------2222222",
            "22222222222----------",
            "---222222---222222222",


            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",
            "111111111111111111111",

            "-----33333-----------",
            "3333-33333-333333----",
            "3333-33333-333333----",
            "3333-------333333-333",
            "3333-333333-------333",
            "3333-333333333333-333",
            "3333-333333333333-333",
            "-----------333333----",
            "333333333333---------",
            "333333333333-33333333",
            "333333333333-33333333",
            "333333333333-33333333",
            "333333333333-33333333"
        };
    }
}