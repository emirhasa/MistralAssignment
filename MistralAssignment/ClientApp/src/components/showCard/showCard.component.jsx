import { Card, Grid } from '@material-ui/core';
import React from 'react';
import formatDateFromIsoString from '../helper/dateFormat';

const ShowCard = (props) => {

    return (
        <Card className="show-card" variant="outlined">
            <Grid item container xs={12} sm={10} md={8} lg={6} xl={5} spacing={1}>
                <Grid item xs={12} lg={3}>
                    <img className="show-card__image" src={`data:image/jpeg;base64,${props.show.showImage}`} />
                </Grid>
                <Grid item container xs={12} lg={9}>
                    <Grid item container xs={12} className="show-card__info-row">
                        <Grid item xs={6}>
                            <strong>Title</strong>
                            <br />
                            <strong>{props.show.title}</strong>
                        </Grid>
                        <Grid item xs={6}>
                            <strong>Release date</strong>
                            <br />
                            {formatDateFromIsoString(props.show.releaseDate)}
                        </Grid>
                    </Grid>
                    <Grid item container xs={12} className="show-card__info-row">
                        <Grid item xs={6}>
                            <strong>Cast</strong>
                            <br />
                            {props.show.cast.map(showActor => showActor.actor.name).join(", ")}
                        </Grid>
                        <Grid item xs={6}>
                            <strong>Rating</strong>
                            <br />
                            {props.show.averageRating}
                        </Grid>
                    </Grid>
                    <Grid item xs={12} className="show-card__description">
                        <strong>Description</strong>
                        <br />
                        {props.show.description}
                    </Grid>
                </Grid>
            </Grid>
        </Card>
    )
}

export default ShowCard;