import React from 'react';

import { Grid } from '@material-ui/core';

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