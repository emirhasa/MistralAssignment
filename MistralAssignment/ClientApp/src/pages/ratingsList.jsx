import { Button, Card, Grid } from '@material-ui/core';
import React, { useEffect, useState } from 'react';

import API from '../api';
import RatingSlider from '../components/ratingSlider/ratingSlider.component';

const RatingsListPage = () => {

    const [showsList, setShowsList] = useState([]);

    const getShows = async () => {

        const response = await API.get('Show', { params: { take: 100 }});

        setShowsList(response.data.map(show => ({
            showId: show.showId,
            title: show.title,
            averageRating: show.averageRating,
            isRated: false,
            newRating: 3
        })));
    }
    
    useEffect(() => {
        getShows();
    }, [])

    const ratingSliderChange = (showId, newRating) => {

        let newList = showsList;
        newList = newList.map((show) => {
            if (show.showId === showId) {
              const updatedShow = {
                ...show,
                newRating: newRating
              };
       
              console.log(updatedShow);
              return updatedShow;
            }
       
            return show;
          });
          
        setShowsList([...newList]);
    }

    const rateShow = async (showId) => {
        const ratedShow = showsList.find(show => show.showId == showId);
        
        await API.post('Rating', { showId: showId, grade: ratedShow.newRating});

        const newShowData = (await API.get(`Show/${showId}`)).data;

        let newList = showsList;
        newList = newList.map((show) => {
            if (show.showId === showId) {
              const updatedShow = {
                ...newShowData,
                isRated: true,
                newRating: ratedShow.newRating
              };
       
              return updatedShow;
            }
       
            return show;
          });

        setShowsList([...newList]);
    }

    return (
        <Grid container>
            <Grid xs={12} md={9} lg={6}>
            {
                showsList.map(show => (
                    <Card variant="outlined" key={show.showId}>
                        <Grid container>
                            <Grid item xs={12} lg={3}>
                                {show.title}
                            </Grid>
                            <Grid item xs={6} lg={3}>
                                <RatingSlider key={show.showId} showId={show.showId}  name="Rate here" disabled={show.isRated} defaultValue={show.newRating} step={1} onChangeCommitted={(event, value) => {ratingSliderChange(show.showId, value)}}  />
                            </Grid>
                            <Grid item xs={6} lg={3}>
                                <Button variant="outlined" disabled={show.isRated} onClick={() => { rateShow(show.showId)}}>
                                    Rate
                                </Button>
                            </Grid>
                            <Grid item xs={6} lg={3}>
                                <RatingSlider key={show.showId} showId={show.showId} name="Avg rating" disabled={true} step={0.1} defaultValue={show.averageRating.toFixed(1)} />
                            </Grid>
                        </Grid>
                    </Card>
                ))
            }
            </Grid>
        </Grid>
    )
}

export default RatingsListPage;