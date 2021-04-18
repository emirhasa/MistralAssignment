import React, { useEffect, useState } from 'react';

import { Card, FormControl, Grid, IconButton, Input, InputAdornment, InputLabel, Paper } from '@material-ui/core';

import ShowCard from '../showCard/showCard.component';

const ShowList = (props) => {

    return (
        <Grid container>
            {props.shows.map(show => (
                <ShowCard
                    show={show}
                    key={show.showId}
                 />
            ))}
        </Grid>
    )
}

export default ShowList;